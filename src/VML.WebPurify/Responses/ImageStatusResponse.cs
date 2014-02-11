// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageStatusResponse.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 9:25 AM</created>
//  <updated>02/11/2014 9:31 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using RestSharp.Serializers;

#endregion

namespace VML.WebPurify.Responses
{
    [SerializeAs(Name = "rsp")]
    public class ImageStatusResponse : ImageResponseBase
    {
        #region Public Properties

        [SerializeAs(Name = "mdate")]
        public DateTime MDate { get; set; }

        [SerializeAs(Name = "sdate")]
        public DateTime SDate { get; set; }

        #endregion
    }
}