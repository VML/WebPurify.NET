// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IntegrationTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 11:41 AM</created>
//  <updated>02/11/2014 11:42 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

#endregion

namespace VML.WebPurify.Tests
{
    public class IntegrationTests
    {
        #region Public Methods

        [Fact]
        public void Client_BadApiKey_Throws()
        {
            var client = new WebPurifyClient("bad api key", true);

            client.Invoking(c => c.ImageAccount()).ShouldThrow<Exception>();
        }

        #endregion
    }
}