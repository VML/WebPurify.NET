// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageCheckResponse.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 5:08 PM</created>
//  <updated>02/10/2014 5:22 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using RestSharp.Deserializers;
using RestSharp.Serializers;

#endregion

namespace VML.WebPurify.Responses
{
    [SerializeAs(Name = "rsp")]
    public class ImageCheckResponse
    {
        #region Public Properties

        [SerializeAs(Name = "api_key")]
        [DeserializeAs(Name = "api_key")]
        public string ApiKey { get; set; }

        [SerializeAs(Name = "format")]
        public string Format { get; set; }

        [SerializeAs(Name = "imgid")]
        [DeserializeAs(Name = "imgid")]
        public string ImageId { get; set; }

        [SerializeAs(Name = "method")]
        public string Method { get; set; }

        [SerializeAs(Name = "stat", Attribute = true)]
        [DeserializeAs(Name = "stat", Attribute = true)]
        public string ResponseStatus { get; set; }

        [SerializeAs(Name = "status")]
        public string Status { get; set; }

        #endregion
    }
}