﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageCheckResponseTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 5:15 PM</created>
//  <updated>02/10/2014 5:51 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using FluentAssertions;
using RestSharp;
using RestSharp.Deserializers;
using VML.WebPurify.Responses;
using Xunit;

#endregion

namespace VML.WebPurify.Tests.ResponseTests
{
    public class ImageCheckResponseTests
    {
        #region Constants and Fields

        private const string SampleXml =
            @"<rsp stat=""ok""><imgid>7de93bc200ff21a26da6ddb115506e82</imgid><status>pending</status><api_key>f3412a9614845dc17d97a5d51a647a13</api_key><format>rest</format><method>webpurify.live.imgcheck</method></rsp>";

        #endregion

        #region Public Methods

        [Fact]
        public void DeserializesProperly()
        {
            RestResponse response = new RestResponse { Content = SampleXml };
            XmlAttributeDeserializer deserializer = new XmlAttributeDeserializer();
            var imageCheckResponse = deserializer.Deserialize<ImageCheckResponse>(response);

            imageCheckResponse.Method.Should().Be("webpurify.live.imgcheck");
            imageCheckResponse.Format.Should().Be("rest");
            imageCheckResponse.ImageId.Should().Be("7de93bc200ff21a26da6ddb115506e82");
            imageCheckResponse.Status.Should().Be(ImageStatus.Pending);
            imageCheckResponse.ApiKey.Should().Be("f3412a9614845dc17d97a5d51a647a13");
            imageCheckResponse.ResponseStatus.Should().Be("ok");
        }

        #endregion
    }
}