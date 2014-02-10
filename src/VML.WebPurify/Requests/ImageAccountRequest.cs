﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AccountRequest.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 3:47 PM</created>
//  <updated>02/10/2014 3:48 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;

#endregion

namespace VML.WebPurify.Requests
{
    public class ImageAccountRequest : RequestBase
    {
        #region Constructors and Destructors

        public ImageAccountRequest()
        {
            Method = ApiMethod.Account;
        }

        #endregion
    }
}