// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEndpoints.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 10:26 AM</created>
//  <updated>02/11/2014 10:42 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System.Linq;
using System;

#endregion

namespace VML.WebPurify.Interfaces
{
    public interface IEndpoints
    {
        #region Public Properties

        Uri ImageModerationEndpoint { get; }

        #endregion
    }
}