// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageAccountResponse.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 9:38 AM</created>
//  <updated>02/11/2014 9:39 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using RestSharp.Serializers;

#endregion

namespace VML.WebPurify.Responses
{
    [SerializeAs(Name = "rsp")]
    public class ImageAccountResponse : ResponseBase
    {
        #region Public Properties

        public int Remaining { get; set; }

        #endregion
    }
}