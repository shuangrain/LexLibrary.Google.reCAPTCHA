using LexLibrary.Google.reCAPTCHA.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LexLibrary.GovEinvoice
{
    public static class GoogleCaptchaCollectionExtensions
    {
        public static IServiceCollection AddGoogleCaptcha(this IServiceCollection services, GoogleCaptchaSetting setting)
        {
            services.AddSingleton((sp) => setting);
            return services;
        }
    }
}
