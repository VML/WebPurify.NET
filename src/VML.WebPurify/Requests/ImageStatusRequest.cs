// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageStatusRequest.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 3:52 PM</created>
//  <updated>02/10/2014 4:18 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using RestSharp;

#endregion

namespace VML.WebPurify.Requests
{
    public class ImageStatusRequest : RequestBase
    {
        #region Constructors and Destructors

        public ImageStatusRequest()
        {
            Method = ApiMethod.Status;
        }

        #endregion

        #region Public Properties

        public string ImageId { get; set; }

        #endregion

        #region Public Methods

        public override Parameter[] GetParameters()
        {
            Parameter[] baseParams = base.GetParameters();

            return baseParams.Union(
                new[]
                    {
                        new Parameter { Name = "imgid", Value = ImageId }
                    }).ToArray();
        }

        #endregion
    }
}