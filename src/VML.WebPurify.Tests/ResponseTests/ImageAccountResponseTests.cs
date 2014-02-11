// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageAccountResponseTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 9:38 AM</created>
//  <updated>02/11/2014 9:40 AM by Ben Ramey</updated>
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
    public class ImageAccountResponseTests
    {
        #region Constants and Fields

        private const string SampleXml =
            @"<rsp stat=""ok""><method>webpurify.live.imgaccount</method><format>rest</format><remaining>151</remaining><api_key>f3412a9614845dc17d97a5d51a647a13</api_key></rsp>";

        #endregion

        #region Public Methods

        [Fact]
        public void DeserializesProperly()
        {
            RestResponse response = new RestResponse { Content = SampleXml };
            XmlAttributeDeserializer deserializer = new XmlAttributeDeserializer();
            var imageCheckResponse = deserializer.Deserialize<ImageAccountResponse>(response);

            imageCheckResponse.Method.Should().Be("webpurify.live.imgaccount");
            imageCheckResponse.Format.Should().Be("rest");
            imageCheckResponse.Remaining.Should().Be(151);
            imageCheckResponse.ApiKey.Should().Be("f3412a9614845dc17d97a5d51a647a13");
            imageCheckResponse.ResponseStatus.Should().Be("ok");
        }

        #endregion
    }
}