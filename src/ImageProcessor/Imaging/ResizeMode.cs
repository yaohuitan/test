﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResizeMode.cs" company="James South">
//   Copyright (c) James South.
//   Licensed under the Apache License, Version 2.0.
// </copyright>
// <summary>
//   Enumerated resize modes to apply to resized images.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageProcessor.Imaging
{
    /// <summary>
    /// Enumerated resize modes to apply to resized images.
    /// </summary>
    public enum ResizeMode
    {
        /// <summary>
        /// Pads the resized image to fit the bounds of its container.
        /// </summary>
        Pad,

        /// <summary>
        /// Stretches the resized image to fit the bounds of its container.
        /// </summary>
        Stretch,

        /// <summary>
        /// Crops the resized image to fit the bounds of its container.
        /// </summary>
        Crop,

        /// <summary>
        /// Constrains the resized image to fit the bounds of its container. 
        /// </summary>
        Max,

        /// <summary>
        /// Resizes the image until the shortest side reaches the set given dimension.
        /// Sets <see cref="ResizeLayer.Upscale"/> to <c>false</c>.
        /// </summary>
        Min,

        /// <summary>
        /// Pads the image to fit the bound of the container without resizing the 
        /// original source. Sets <see cref="ResizeLayer.Upscale"/> to <c>true</c>.
        /// </summary>
        BoxPad
    }
}
