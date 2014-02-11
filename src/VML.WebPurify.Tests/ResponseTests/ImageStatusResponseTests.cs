// --------------------------------------------------------------------------------------------------------------------
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
    public class ImageStatusResponseTests
    {
        #region Constants and Fields

        private const string SampleXml =
            @"<rsp stat=""ok""><method>webpurify.live.imgstatus</method><format>rest</format><imgid>7de93bc200ff21a26da6ddb115506e82</imgid><sdate>2010-11-26 00:02:39</sdate><mdate>2010-11-26 00:03:01</mdate><status>approved</status><api_key>f3412a9614845dc17d97a5d51a647a13</api_key></rsp>";

        #endregion

        #region Public Methods

        [Fact]
        public void DeserializesProperly()
        {
            RestResponse response = new RestResponse { Content = SampleXml };
            XmlAttributeDeserializer deserializer = new XmlAttributeDeserializer();
            var imageStatusResponse = deserializer.Deserialize<ImageStatusResponse>(response);

            imageStatusResponse.Method.Should().Be("webpurify.live.imgstatus");
            imageStatusResponse.Format.Should().Be("rest");
            imageStatusResponse.ImageId.Should().Be("7de93bc200ff21a26da6ddb115506e82");
            imageStatusResponse.Status.Should().Be(ImageStatus.Approved);
            imageStatusResponse.ApiKey.Should().Be("f3412a9614845dc17d97a5d51a647a13");
            imageStatusResponse.SDate.Should().Be(DateTime.Parse("2010-11-26 00:02:39"));
            imageStatusResponse.MDate.Should().Be(DateTime.Parse("2010-11-26 00:03:01"));
            imageStatusResponse.ResponseStatus.Should().Be("ok");
        }

        #endregion
    }
}