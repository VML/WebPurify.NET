// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageStatus.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 9:27 AM</created>
//  <updated>02/11/2014 9:27 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;

#endregion

namespace VML.WebPurify.Responses
{
    public enum ImageStatus
    {
        Pending,
        Approved,
        Declined
    }
}