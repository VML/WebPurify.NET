// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CheckRequestTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 4:04 PM</created>
//  <updated>02/10/2014 4:04 PM by Ben Ramey</updated>
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
    public class ImageCheckRequestTests
    {
        #region Public Methods

        [Fact]
        public void GetParameters_ReturnsCorrectParameters()
        {
            ImageCheckRequest request = new ImageCheckRequest();

            request.ApiKey = "apikey";
            request.ImageUri = new Uri("http://example.com/image");

            Parameter[] parameters = request.GetParameters();

            parameters.Any(p => p.Name == "method").Should().BeTrue();
            parameters.Any(p => p.Name == "imgurl").Should().BeTrue();
            parameters.Any(p => p.Name == "api_key").Should().BeTrue();

            parameters.First(p => p.Name == "method").Value.Should().Be("webpurify.live.imgcheck");
            parameters.First(p => p.Name == "imgurl").Value.Should().Be(request.ImageUri.ToString());
            parameters.First(p => p.Name == "api_key").Value.Should().Be(request.ApiKey);
        }

        #endregion
    }
}