﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ImageCheckResponse.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/10/2014 5:08 PM</created>
//  <updated>02/11/2014 9:34 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Linq;
using RestSharp.Serializers;

#endregion

namespace VML.WebPurify.Responses
{
    [SerializeAs(Name = "rsp")]
    public class ImageCheckResponse : ImageResponseBase
    {
    }
}