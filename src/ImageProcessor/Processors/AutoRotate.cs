﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoRotate.cs" company="James South">
//   Copyright (c) James South.
//   Licensed under the Apache License, Version 2.0.
// </copyright>
// <summary>
//   Performs auto-rotation to ensure that EXIF defined rotation is reflected in
//   the final image.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageProcessor.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    using ImageProcessor.Common.Exceptions;
    using ImageProcessor.Imaging.MetaData;

    /// <summary>
    /// Performs auto-rotation to ensure that EXIF defined rotation is reflected in 
    /// the final image.
    /// </summary>
    public class AutoRotate : IGraphicsProcessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoRotate"/> class.
        /// </summary>
        public AutoRotate()
        {
            this.Settings = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets DynamicParameter.
        /// </summary>
        public dynamic DynamicParameter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets any additional settings required by the processor.
        /// </summary>
        public Dictionary<string, string> Settings
        {
            get;
            set;
        }

        /// <summary>
        /// Processes the image.
        /// </summary>
        /// <param name="factory">The current instance of the 
        /// <see cref="T:ImageProcessor.ImageFactory" /> class containing
        /// the image to process.</param>
        /// <returns>
        /// The processed image from the current instance of the <see cref="T:ImageProcessor.ImageFactory" /> class.
        /// </returns>
        public Image ProcessImage(ImageFactory factory)
        {
            Image image = factory.Image;

            try
            {
                const int Orientation = (int)ExifPropertyTag.Orientation;
                if (!factory.PreserveExifData && factory.ExifPropertyItems.ContainsKey(Orientation))
                {
                    int rotationValue = factory.ExifPropertyItems[Orientation].Value[0];
                    switch (rotationValue)
                    {
                        case 8: // Rotated 90 right
                            // De-rotate:
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;

                        case 3: // Bottoms up
                            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;

                        case 6: // Rotated 90 left
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                    }
                }

                return image;
            }
            catch (Exception ex)
            {
                throw new ImageProcessingException("Error processing image with " + this.GetType().Name, ex);
            }
        }
    }
}