# WebPurify.NET

C# wrapper for WebPurify.com API.

Currently, this library only includes methods for WebPurify's image moderation functionality.  See their documentation here: [http://webpurify.com/image-moderation/documentation/](http://webpurify.com/image-moderation/documentation/)

## Basic usage

    var client = new WebPurifyClient("<api_key>");
  
    Uri imageUri = new Uri("http://example.com/image.jpg");
    ImageCheckResponse response = client.ImageCheck(imageUri);
