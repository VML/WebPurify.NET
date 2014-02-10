// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageAccountRequestTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 4:18 PM</created>
//  <updated>02/10/2014 4:19 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using FluentAssertions;
using RestSharp;
using VML.WebPurify.Requests;
using Xunit;

#endregion

namespace VML.WebPurify.Tests
{
    public class ImageAccountRequestTests
    {
        #region Public Methods

        [Fact]
        public void GetParameters_ReturnsCorrectParameters()
        {
            ImageAccountRequest request = new ImageAccountRequest();

            request.ApiKey = "apikey";

            Parameter[] parameters = request.GetParameters();

            parameters.Any(p => p.Name == "method").Should().BeTrue();
            parameters.Any(p => p.Name == "api_key").Should().BeTrue();

            parameters.First(p => p.Name == "method").Value.Should().Be("webpurify.live.imgaccount");
            parameters.First(p => p.Name == "api_key").Value.Should().Be(request.ApiKey);
        }

        #endregion
    }
}