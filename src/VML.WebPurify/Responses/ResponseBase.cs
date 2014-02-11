// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ResponseBase.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 9:28 AM</created>
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
    public abstract class ResponseBase
    {
        #region Public Properties

        [DeserializeAs(Name = "api_key")]
        public string ApiKey { get; set; }

        public string Format { get; set; }

        public string Method { get; set; }

        [DeserializeAs(Name = "stat", Attribute = true)]
        public string ResponseStatus { get; set; }

        #endregion
    }
}