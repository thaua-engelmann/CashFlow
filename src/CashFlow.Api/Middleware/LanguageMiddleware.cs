using System.Globalization;

namespace CashFlow.Api.Middleware;

public class LanguageMiddleware
{

    private readonly RequestDelegate _next;
    public LanguageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {

        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
        var requestedLanguage = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var isRequestedLanguageSupported = supportedLanguages.Exists(language => language.Name.Equals(requestedLanguage));

        CultureInfo cultureInfo;

        if (!string.IsNullOrWhiteSpace(requestedLanguage) && isRequestedLanguageSupported)
        {
            cultureInfo = new CultureInfo(requestedLanguage);
        }
        else
        {
            // Default language "en". 
            cultureInfo = new CultureInfo("en");
        }

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }

}
