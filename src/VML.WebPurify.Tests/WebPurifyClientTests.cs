// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WebPurifyClientTests.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 3:36 PM</created>
//  <updated>02/10/2014 6:01 PM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using System.Net;
using FluentAssertions;
using NSubstitute;
using RestSharp;
using VML.WebPurify.Endpoints;
using VML.WebPurify.Responses;
using Xunit;
using Xunit.Extensions;

#endregion

namespace VML.WebPurify.Tests
{
    public class WebPurifyClientTests
    {
        #region Constants and Fields

        private readonly WebPurifyClient _client;
        private readonly IRestClient _restClientMock;

        #endregion

        #region Constructors and Destructors

        public WebPurifyClientTests()
        {
            _restClientMock = Substitute.For<IRestClient>();
            _client = new WebPurifyClient("fake_apikey", _restClientMock);

            _restClientMock.BaseUrl.Returns("http://example.com");
            _restClientMock
                .Post<ImageCheckResponse>(new RestRequest())
                .ReturnsForAnyArgs(
                    new RestResponse<ImageCheckResponse> { StatusCode = HttpStatusCode.OK });
        }

        #endregion

        #region Public Methods

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Constructor_InvalidKey_Throws(string apiKey)
        {
            Assert.Throws<ArgumentException>(() => new WebPurifyClient(apiKey));
            Assert.Throws<ArgumentException>(() => new WebPurifyClient(new DefaultHttpEndpoints(), apiKey));
        }

        [Fact]
        public void ImageAccount_CallsGetOnce()
        {
            _client.ImageAccount();

            _restClientMock.ReceivedWithAnyArgs(1).Get(new RestRequest());
        }

        [Fact]
        public void ImageAccount_CallsGetWithCorrectParameters()
        {
            IRestRequest request = null;
            _restClientMock.WhenForAnyArgs(c => c.Get(new RestRequest()))
                           .Do(ci => request = (IRestRequest)ci.Args()[0]);

            _client.ImageAccount();

            request.Should().NotBeNull();
            request.Parameters.Should().NotBeNull();

            request.Parameters.Any(p => p.Name == "api_key").Should().BeTrue();
            request.Parameters.Any(p => p.Name == "method").Should().BeTrue();

            request.Parameters.First(p => p.Name == "api_key").Value.Should().Be("fake_apikey");
            request.Parameters.First(p => p.Name == "method").Value.Should().Be("webpurify.live.imgaccount");
        }

        [Fact]
        public void ImageCheck_CallsPostOnce()
        {
            Uri imageUri = new Uri("http://example.com");

            _client.ImageCheck(imageUri);

            _restClientMock.ReceivedWithAnyArgs(1).Post<ImageCheckResponse>(new RestRequest());
        }

        [Fact]
        public void ImageCheck_CallsPostWithCorrectParameters()
        {
            Uri imageUri = new Uri("http://example.com");

            IRestRequest request = null;
            _restClientMock.WhenForAnyArgs(c => c.Post<ImageCheckResponse>(new RestRequest()))
                           .Do(ci => request = (IRestRequest)ci.Args()[0]);

            _client.ImageCheck(imageUri);

            request.Should().NotBeNull();
            request.Parameters.Should().NotBeNull();

            request.Parameters.Any(p => p.Name == "api_key").Should().BeTrue();
            request.Parameters.Any(p => p.Name == "imgurl").Should().BeTrue();
            request.Parameters.Any(p => p.Name == "method").Should().BeTrue();

            request.Parameters.First(p => p.Name == "api_key").Value.Should().Be("fake_apikey");
            request.Parameters.First(p => p.Name == "imgurl").Value.Should().Be(imageUri.ToString());
            request.Parameters.First(p => p.Name == "method").Value.Should().Be("webpurify.live.imgcheck");
        }

        [Fact]
        public void ImageCheck_NullImageUrl_Throws()
        {
            _client.Invoking(c => c.ImageCheck(null)).ShouldThrow<ArgumentNullException>();
        }

        [Theory]
        [InlineData(HttpStatusCode.Ambiguous)]
        [InlineData(HttpStatusCode.BadGateway)]
        [InlineData(HttpStatusCode.BadRequest)]
        [InlineData(HttpStatusCode.Conflict)]
        [InlineData(HttpStatusCode.ExpectationFailed)]
        [InlineData(HttpStatusCode.Forbidden)]
        [InlineData(HttpStatusCode.GatewayTimeout)]
        [InlineData(HttpStatusCode.HttpVersionNotSupported)]
        [InlineData(HttpStatusCode.InternalServerError)]
        [InlineData(HttpStatusCode.MethodNotAllowed)]
        [InlineData(HttpStatusCode.Unauthorized)]
        [InlineData(HttpStatusCode.SeeOther)]
        [InlineData(HttpStatusCode.RequestTimeout)]
        [InlineData(HttpStatusCode.NotImplemented)]
        [InlineData(HttpStatusCode.NotAcceptable)]
        [InlineData(HttpStatusCode.NotFound)]
        public void ImageCheck_ResponseHasHttpError_Throws(HttpStatusCode status)
        {
            Uri imageUri = new Uri("http://example.com");
            _restClientMock
                .Post<ImageCheckResponse>(new RestRequest())
                .ReturnsForAnyArgs(
                    new RestResponse<ImageCheckResponse> { StatusCode = status });

            _client.Invoking(c => c.ImageCheck(imageUri))
                   .ShouldThrow<Exception>();
        }

        [Fact]
        public void ImageStatus_CallsGetOnce()
        {
            _client.ImageStatus("fake_image_id");

            _restClientMock.ReceivedWithAnyArgs(1).Get(new RestRequest());
        }

        [Fact]
        public void ImageStatus_CallsGetWithCorrectParameters()
        {
            string imageId = "fake_image_id";

            IRestRequest request = null;
            _restClientMock.WhenForAnyArgs(c => c.Get(new RestRequest()))
                           .Do(ci => request = (IRestRequest)ci.Args()[0]);

            _client.ImageStatus(imageId);

            request.Should().NotBeNull();
            request.Parameters.Should().NotBeNull();

            request.Parameters.Any(p => p.Name == "api_key").Should().BeTrue();
            request.Parameters.Any(p => p.Name == "imgid").Should().BeTrue();
            request.Parameters.Any(p => p.Name == "method").Should().BeTrue();

            request.Parameters.First(p => p.Name == "api_key").Value.Should().Be("fake_apikey");
            request.Parameters.First(p => p.Name == "imgid").Value.Should().Be(imageId);
            request.Parameters.First(p => p.Name == "method").Value.Should().Be("webpurify.live.imgstatus");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void ImageStatus_InvalidImageId_Throws(string imageId)
        {
            _client.Invoking(c => c.ImageStatus(imageId)).ShouldThrow<ArgumentNullException>();
        }

        #endregion
    }
}