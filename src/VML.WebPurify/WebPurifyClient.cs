// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WebPurifyClient.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 3:54 PM</created>
//  <updated>02/10/2014 4:19 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#define USETHROWER

#region Usings

using System;
using System.Linq;
using Thrower;

#endregion

namespace VML.WebPurify
{
    public class WebPurifyClient
    {
        #region Constructors and Destructors

        public WebPurifyClient(string apiKey)
        {
            Raise<ArgumentException>.If(string.IsNullOrWhiteSpace(apiKey));
        }

        #endregion

        #region Public Methods

        public void CheckImage(Uri imageUrl)
        {
            Raise<ArgumentNullException>.IfIsNull(imageUrl);
        }

        #endregion
    }
}