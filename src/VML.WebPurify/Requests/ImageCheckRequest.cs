// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageCheckRequest.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 3:52 PM</created>
//  <updated>02/10/2014 4:19 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using RestSharp;

#endregion

namespace VML.WebPurify.Requests
{
    public class ImageCheckRequest : RequestBase
    {
        #region Constructors and Destructors

        public ImageCheckRequest()
        {
            Method = ApiMethod.Check;
        }

        #endregion

        #region Public Properties

        public Uri ImageUri { get; set; }

        #endregion

        #region Public Methods

        public override Parameter[] GetParameters()
        {
            Parameter[] baseParams = base.GetParameters();

            return baseParams.Union(
                new[]
                    {
                        new Parameter { Name = "imgurl", Value = ImageUri.ToString() }
                    }).ToArray();
        }

        #endregion
    }
}