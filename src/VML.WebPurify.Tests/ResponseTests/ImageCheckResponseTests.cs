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
    public class ImageCheckResponseTests
    {
        #region Constants and Fields

        private const string SampleXml =
            @"<rsp stat=""ok""><api_key>f3412a9614845dc17d97a5d51a647a13</api_key><format>rest</format><imgid>7de93bc200ff21a26da6ddb115506e82</imgid><method>webpurify.live.imgcheck</method><status>pending</status></rsp>";

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
            imageCheckResponse.Status.Should().Be("pending");
            imageCheckResponse.ApiKey.Should().Be("f3412a9614845dc17d97a5d51a647a13");
            imageCheckResponse.ResponseStatus.Should().Be("ok");
        }

        [Fact]
        public void SerializesProperly()
        {
            var expectedResponse = new ImageCheckResponse();
            expectedResponse.Method = "webpurify.live.imgcheck";
            expectedResponse.Format = "rest";
            expectedResponse.ImageId = "7de93bc200ff21a26da6ddb115506e82";
            expectedResponse.Status = "pending";
            expectedResponse.ApiKey = "f3412a9614845dc17d97a5d51a647a13";
            expectedResponse.ResponseStatus = "ok";

            RestRequest request = new RestRequest();
            string xml = request.XmlSerializer.Serialize(expectedResponse).Replace("\r\n", "").Replace(">  <", "><");

            xml.Should().Be(SampleXml);
        }

        #endregion
    }
}