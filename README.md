# WebPurify.NET

C# wrapper for WebPurify.com API.

Currently, this library only includes methods for WebPurify's image moderation functionality.  See their documentation here: [http://webpurify.com/image-moderation/documentation/](http://webpurify.com/image-moderation/documentation/)

## Basic usage
Usage is very simple.  Create a `WebPurifyClient`, passing it the API key that you have purchased from WebPurify.  Once this is done, you can call the `ImageCheck()`, `ImageAccount()` and `ImageStatus()` methods as you please.

    var client = new WebPurifyClient("<api_key>");
  
    Uri imageUri = new Uri("http://example.com/image.jpg");
    ImageCheckResponse response = client.ImageCheck(imageUri);
