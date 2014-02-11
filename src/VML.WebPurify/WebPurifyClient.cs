// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WebPurifyClient.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 3:54 PM</created>
//  <updated>02/11/2014 9:49 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#define USETHROWER

#region Usings

using System;
using System.Linq;
using System.Net;
using RestSharp;
using Thrower;
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
        private readonly IRestClient _restClient;

        #endregion

        #region Constructors and Destructors

        public WebPurifyClient(IEndpoints endpoints, string apiKey)
        {
            Raise<ArgumentException>.If(string.IsNullOrWhiteSpace(apiKey));

            _restClient = new RestClient();
            _apiKey = apiKey;
        }

        public WebPurifyClient(string apiKey)
            : this(null, apiKey)
        {
        }

        public WebPurifyClient(string apiKey, IRestClient restClient)
            : this(null, apiKey)
        {
            _restClient = restClient;
        }

        #endregion

        #region Public Methods

        public ImageAccountResponse ImageAccount()
        {
            ImageAccountRequest imageAccountRequest = new ImageAccountRequest
                {
                    ApiKey = _apiKey
                };

            RestRequest request = new RestRequest(Method.GET);
            request.Parameters.AddRange(imageAccountRequest.GetParameters());

            IRestResponse<ImageAccountResponse> response = _restClient.Get<ImageAccountResponse>(request);
            ThrowIfError(response);
            return response.Data;
        }

        public ImageCheckResponse ImageCheck(Uri imageUri)
        {
            Raise<ArgumentNullException>.IfIsNull(imageUri);

            ImageCheckRequest imageCheckRequest = new ImageCheckRequest
                {
                    ApiKey = _apiKey,
                    ImageUri = imageUri
                };

            RestRequest request = new RestRequest(Method.POST);
            request.Parameters.AddRange(imageCheckRequest.GetParameters());

            IRestResponse<ImageCheckResponse> response = _restClient.Post<ImageCheckResponse>(request);
            ThrowIfError(response);
            return response.Data;
        }

        public ImageStatusResponse ImageStatus(string imageId)
        {
            Raise<ArgumentNullException>.If(string.IsNullOrWhiteSpace(imageId));

            ImageStatusRequest imageStatusRequest = new ImageStatusRequest
                {
                    ApiKey = _apiKey,
                    ImageId = imageId
                };

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
            Raise<Exception>.If(response.StatusCode != HttpStatusCode.OK, "API response was not OK.");
        }

        #endregion
    }
}