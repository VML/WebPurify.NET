// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageResponseBase.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 9:31 AM</created>
//  <updated>02/11/2014 9:31 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using RestSharp.Deserializers;
using RestSharp.Serializers;

#endregion

namespace VML.WebPurify.Responses
{
    public abstract class ImageResponseBase : ResponseBase
    {
        #region Public Properties

        [SerializeAs(Name = "imgid")]
        [DeserializeAs(Name = "imgid")]
        public string ImageId { get; set; }

        [SerializeAs(Name = "status")]
        public ImageStatus Status { get; set; }

        #endregion
    }
}