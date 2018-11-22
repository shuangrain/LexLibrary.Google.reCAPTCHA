using System;
using System.Collections.Generic;
using System.Text;

namespace LexLibrary.Google.reCAPTCHA.Models
{
    public class ResponseDTO
    {
        public bool Success { get; set; }

        public string Challenge_ts { get; set; }

        public string Hostname { get; set; }

        public string[] Errorcodes { get; set; }

        /// <summary>
        /// the score for this request (0.0 - 1.0)
        /// v3 才有
        /// </summary>
        public float Score { get; set; }

        /// <summary>
        /// the action name for this request (important to verify)
        /// v3 才有
        /// </summary>
        public string Action { get; set; }
    }
}
