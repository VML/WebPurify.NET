// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WebPurifyClientTests.data.cs" company="VML">
//   Copyright VML 2014. All rights reserved.
//  </copyright>
//  <created>02/11/2014 9:41 AM</created>
//  <updated>02/11/2014 9:43 AM by Ben Ramey</updated>
// --------------------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

#endregion

namespace VML.WebPurify.Tests
{
    public partial class WebPurifyClientTests
    {
        #region Public Properties

        public static IEnumerable<object[]> InvalidHttpStatusCodes
        {
            get
            {
                return new[]
                    {
                        new object[] { HttpStatusCode.Ambiguous },
                        new object[] { HttpStatusCode.BadGateway },
                        new object[] { HttpStatusCode.BadRequest },
                        new object[] { HttpStatusCode.Conflict },
                        new object[] { HttpStatusCode.ExpectationFailed },
                        new object[] { HttpStatusCode.Forbidden },
                        new object[] { HttpStatusCode.GatewayTimeout },
                        new object[] { HttpStatusCode.HttpVersionNotSupported },
                        new object[] { HttpStatusCode.InternalServerError },
                        new object[] { HttpStatusCode.MethodNotAllowed },
                        new object[] { HttpStatusCode.Unauthorized },
                        new object[] { HttpStatusCode.SeeOther },
                        new object[] { HttpStatusCode.RequestTimeout },
                        new object[] { HttpStatusCode.NotImplemented },
                        new object[] { HttpStatusCode.NotAcceptable },
                        new object[] { HttpStatusCode.NotFound },
                    };
            }
        }

        #endregion
    }
}