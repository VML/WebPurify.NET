using System.Linq;
using System;
using VML.WebPurify.Responses;

namespace VML.WebPurify.Interfaces
{
    public interface IWebPurifyClient
    {
        /// <summary>
        ///     Calls the 'webpurify.live.imgaccount' method.
        /// </summary>
        /// <returns>Response from WebPurify</returns>
        ImageAccountResponse ImageAccount();

        /// <summary>
        ///     Calls the 'webpurify.live.imgcheck' method.
        /// </summary>
        /// <param name="imageUri">URI of image to send to WebPurify for moderation.</param>
        /// <returns>Response from WebPurify</returns>
        ImageCheckResponse ImageCheck(Uri imageUri);

        /// <summary>
        ///     Calls the 'webpurify.live.imgstatus' method.
        /// </summary>
        /// <param name="imageId">ID of image returned to you from a previous ImageCheck call.</param>
        /// <returns>Response from WebPurify</returns>
        ImageStatusResponse ImageStatus(string imageId);
    }
}