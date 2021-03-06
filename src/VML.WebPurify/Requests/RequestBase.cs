﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="RequestBase.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 10:26 AM</created>
//  <updated>02/11/2014 11:46 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

#endregion

namespace VML.WebPurify.Requests
{
    public abstract class RequestBase
    {
        #region Constants and Fields

        private readonly Dictionary<ApiMethod, string> _methodMap = new Dictionary<ApiMethod, string>
            {
                { ApiMethod.Account, "webpurify.{0}.imgaccount" },
                { ApiMethod.Check, "webpurify.{0}.imgcheck" },
                { ApiMethod.Status, "webpurify.{0}.imgstatus" }
            };

        #endregion

        #region Public Properties

        public string ApiKey { get; set; }
        public bool IsSandbox { get; set; }

        #endregion

        #region Properties

        protected ApiMethod Method { get; set; }

        #endregion

        #region Public Methods

        public virtual Parameter[] GetParameters()
        {
            return new[]
                {
                    new Parameter { Name = "api_key", Value = ApiKey, Type = ParameterType.QueryString },
                    new Parameter { Name = "method", Value = GetMethod(), Type = ParameterType.QueryString },
                };
        }

        #endregion

        #region Methods

        private string GetMethod()
        {
            return IsSandbox
                       ? string.Format(_methodMap[Method], "sandbox")
                       : string.Format(_methodMap[Method], "live");
        }

        #endregion
    }
}