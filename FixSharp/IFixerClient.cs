using Fixerr.Models;

namespace Fixerr
{
    public interface IFixerClient
    {
        /// <summary>
        /// The Fixer API comes with a separate currency conversion endpoint, which can be used to convert any amount from one currency to another. 
        /// In order to convert currencies, 
        /// please use the API's convert endpoint, append the from and to parameters and set them to your preferred base and target currency codes.
        /// 
        /// It is also possible to convert currencies using historical exchange rate data. 
        /// To do this, please also use the API's date parameter and set it to your preferred date. (format YYYY-MM-DD)
        /// </summary>
        /// <param name="from">[required] The three-letter currency code of the currency you would like to convert from.</param>
        /// <param name="to">[required] The three-letter currency code of the currency you would like to convert to.</param>
        /// <param name="amount">[required] The amount to be converted.</param>
        /// <param name="historialDate">[optional] Specify a date (format YYYY-MM-DD) to use historical rates for this conversion.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        ValueTask<CurrencyConvertResponse> GetConvertionAsync(string from, string to, int amount, string historialDate = null);

        /// <summary>
        /// Historical rates are available for most currencies all the way back to the year of 1999. You can query the Fixer API for historical rates by appending a date (format YYYY-MM-DD) to the base URL.
        /// </summary>
        /// <param name="sourceDate">Historic Data Only (YYYY-MM-DD)</param>
        /// <param name="baseCurrency">your choice of currency!</param>
        /// <param name="symbols">Comma separated country's name</param>
        /// <returns></returns>
        ValueTask<HistoricRateResponse> GetHistoricRateAsync(DateOnly sourceDate, string baseCurrency = null, string symbols = null);

        /// <summary>
        /// Depending on your subscription plan, the API's latest endpoint will return real-time exchange rate data updated every 60 minutes, every 10 minutes or every 60 seconds.
        /// </summary>
        /// <param name="baseCurrency">Give the base currency, By Default base currency will be set to EUR by the API</param>
        /// <param name="symbols">Comma separated country's name</param>
        /// <returns></returns>
        ValueTask<LatestRateResponse> GetLatestAsync(string baseCurrency = null, string symbols = null);

        /// <summary>
        /// The Fixer API comes with a constantly updated endpoint returning all available currencies. To access this list, make a request to the API's symbols endpoint.
        /// </summary>
        /// <returns></returns>
        ValueTask<SymbolResponse> GetSymbolAsync();
    }
}