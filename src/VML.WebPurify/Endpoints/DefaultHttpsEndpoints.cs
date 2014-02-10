// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DefaultHttpsEndpoints.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 3:52 PM</created>
//  <updated>02/10/2014 3:52 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using VML.WebPurify.Interfaces;

#endregion

namespace VML.WebPurify.Endpoints
{
    public class DefaultHttpsEndpoints : IEndpoints
    {
        #region Public Properties

        public Uri ImageModerationEndpoint
        {
            get
            {
                return new Uri("https://im-api1.webpurify.com/services/rest/");
            }
        }

        #endregion
    }
}