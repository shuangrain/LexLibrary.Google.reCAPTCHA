
using System;
using System.Collections.Generic;
using System.Text;

namespace LexLibrary.Google.reCAPTCHA.Models
{
    public class GoogleCaptchaSetting
    {
        public const string FormKey = "g-recaptcha-response";

        public string ApiVerificationEndpoint { get; set; }

        public string Secretkey { get; set; }

        public string Sitekey { get; set; }
    }
}
