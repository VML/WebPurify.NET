﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageResponseBase.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 9:31 AM</created>
//  <updated>02/11/2014 9:39 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using RestSharp.Deserializers;

#endregion

namespace VML.WebPurify.Responses
{
    public abstract class ImageResponseBase : ResponseBase
    {
        #region Public Properties

        [DeserializeAs(Name = "imgid")]
        public string ImageId { get; set; }

        public ImageStatus Status { get; set; }

        #endregion
    }
}