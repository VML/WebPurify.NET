// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WebPurifyClientTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 3:36 PM</created>
//  <updated>02/10/2014 4:03 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Extensions;

#endregion

namespace VML.WebPurify.Tests
{
    public class WebPurifyClientTests
    {
        #region Constants and Fields

        private readonly WebPurifyClient _client;

        #endregion

        #region Constructors and Destructors

        public WebPurifyClientTests()
        {
            _client = new WebPurifyClient("fake_apikey");
        }

        #endregion

        #region Public Methods

        [Fact]
        public void CheckImage_NullImageUrl_Throws()
        {
            _client.Invoking(c => c.CheckImage(null)).ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_InvalidKey_Throws(string apiKey)
        {
            Assert.Throws<ArgumentException>(() => new WebPurifyClient(apiKey));
        }

        #endregion
    }
}