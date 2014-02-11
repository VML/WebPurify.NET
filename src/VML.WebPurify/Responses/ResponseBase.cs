// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ResponseBase.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 10:26 AM</created>
//  <updated>02/11/2014 11:50 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using RestSharp.Deserializers;

#endregion

namespace VML.WebPurify.Responses
{
    public abstract class ResponseBase
    {
        #region Public Properties

        [DeserializeAs(Name = "api_key")]
        public string ApiKey { get; set; }

        [DeserializeAs(Name = "err")]
        public ResponseError Error { get; set; }

        public string Format { get; set; }

        public string Method { get; set; }

        [DeserializeAs(Name = "stat", Attribute = true)]
        public string ResponseStatus { get; set; }

        #endregion
    }

    public class ResponseError
    {
        #region Public Properties

        [DeserializeAs(Name = "code", Attribute = true)]
        public int Code { get; set; }

        [DeserializeAs(Name = "msg", Attribute = true)]
        public string Message { get; set; }

        #endregion
    }
}