// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEndpoints.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 3:51 PM</created>
//  <updated>02/10/2014 3:51 PM by Ben Ramey</updated>
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