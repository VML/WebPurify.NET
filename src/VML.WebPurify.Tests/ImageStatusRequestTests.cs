// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageStatusRequestTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 4:15 PM</created>
//  <updated>02/10/2014 4:17 PM by Ben Ramey</updated>
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
    public class ImageStatusRequestTests
    {
        #region Public Methods

        [Fact]
        public void GetParameters_ReturnsCorrectParameters()
        {
            ImageStatusRequest request = new ImageStatusRequest();

            request.ApiKey = "apikey";
            request.ImageId = "imageid";

            Parameter[] parameters = request.GetParameters();

            parameters.Any(p => p.Name == "method").Should().BeTrue();
            parameters.Any(p => p.Name == "imgid").Should().BeTrue();
            parameters.Any(p => p.Name == "api_key").Should().BeTrue();

            parameters.First(p => p.Name == "method").Value.Should().Be("webpurify.live.imgstatus");
            parameters.First(p => p.Name == "imgid").Value.Should().Be(request.ImageId);
            parameters.First(p => p.Name == "api_key").Value.Should().Be(request.ApiKey);
        }

        #endregion
    }
}