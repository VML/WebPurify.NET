// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WebPurifyClient.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 3:54 PM</created>
//  <updated>02/11/2014 10:48 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#define USETHROWER

#region Usings

using System;
using System.Linq;
using System.Net;
using RestSharp;
using Thrower;
using VML.WebPurify.Endpoints;
using VML.WebPurify.Interfaces;
using VML.WebPurify.Requests;
using VML.WebPurify.Responses;

#endregion

namespace VML.WebPurify
{
    public class WebPurifyClient
    {
        #region Constants and Fields

        private readonly string _apiKey;
        private readonly IEndpoints _endpoints;
        private readonly IRestClient _restClient;
        private readonly bool _sandbox;

        #endregion

        #region Constructors and Destructors

        public WebPurifyClient(IEndpoints endpoints, string apiKey)
            : this(endpoints, apiKey, false)
        {
        }

        public WebPurifyClient(IEndpoints endpoints, string apiKey, bool sandbox)
        {
            Raise<ArgumentException>.If(string.IsNullOrWhiteSpace(apiKey));

            _sandbox = sandbox;
            _restClient = new RestClient();
            _apiKey = apiKey;
            _endpoints = endpoints ?? new DefaultHttpsEndpoints();
        }

        public WebPurifyClient(string apiKey)
            : this(null, apiKey, false)
        {
        }

        public WebPurifyClient(string apiKey, IRestClient restClient, IEndpoints endpoints, bool sandbox)
            : this(endpoints, apiKey, sandbox)
        {
            _restClient = restClient;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Calls the 'webpurify.live.imgaccount' method.
        /// </summary>
        /// <returns>Response from WebPurify</returns>
        public ImageAccountResponse ImageAccount()
        {
            this.Log().Debug("Image account call");

            ImageAccountRequest imageAccountRequest = new ImageAccountRequest
                {
                    ApiKey = _apiKey,
                    IsSandbox = _sandbox
                };

            _restClient.BaseUrl = _endpoints.ImageModerationEndpoint.ToString();
            RestRequest request = new RestRequest(Method.GET);
            request.Parameters.AddRange(imageAccountRequest.GetParameters());

            IRestResponse<ImageAccountResponse> response = _restClient.Get<ImageAccountResponse>(request);
            ThrowIfError(response);
            return response.Data;
        }

        /// <summary>
        ///     Calls the 'webpurify.live.imgcheck' method.
        /// </summary>
        /// <param name="imageUri">URI of image to send to WebPurify for moderation.</param>
        /// <returns>Response from WebPurify</returns>
        public ImageCheckResponse ImageCheck(Uri imageUri)
        {
            this.Log().Debug("Image check call for image: {0}", imageUri);

            Raise<ArgumentNullException>.IfIsNull(imageUri);

            ImageCheckRequest imageCheckRequest = new ImageCheckRequest
                {
                    ApiKey = _apiKey,
                    ImageUri = imageUri,
                    IsSandbox = _sandbox
                };

            _restClient.BaseUrl = _endpoints.ImageModerationEndpoint.ToString();
            RestRequest request = new RestRequest(Method.POST);
            request.Parameters.AddRange(imageCheckRequest.GetParameters());

            IRestResponse<ImageCheckResponse> response = _restClient.Post<ImageCheckResponse>(request);
            ThrowIfError(response);
            return response.Data;
        }

        /// <summary>
        ///     Calls the 'webpurify.live.imgstatus' method.
        /// </summary>
        /// <param name="imageId">ID of image returned to you from a previous ImageCheck call.</param>
        /// <returns>Response from WebPurify</returns>
        public ImageStatusResponse ImageStatus(string imageId)
        {
            this.Log().Debug("Image status call for ID: {0}", imageId);

            Raise<ArgumentNullException>.If(string.IsNullOrWhiteSpace(imageId));

            ImageStatusRequest imageStatusRequest = new ImageStatusRequest
                {
                    ApiKey = _apiKey,
                    ImageId = imageId,
                    IsSandbox = _sandbox
                };

            _restClient.BaseUrl = _endpoints.ImageModerationEndpoint.ToString();
            RestRequest request = new RestRequest(Method.GET);
            request.Parameters.AddRange(imageStatusRequest.GetParameters());

            IRestResponse<ImageStatusResponse> response = _restClient.Get<ImageStatusResponse>(request);
            ThrowIfError(response);
            return response.Data;
        }

        #endregion

        #region Methods

        private void ThrowIfError(IRestResponse response)
        {
            if (response.ErrorException != null)
            {
                this.Log().Error(() => "Response exception", response.ErrorException);
            }
            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
            {
                this.Log().Error("Response error: {0}", response.ErrorMessage);
            }

            Raise<Exception>.If(response.StatusCode != HttpStatusCode.OK, "API response was not OK.");
        }

        #endregion
    }
}