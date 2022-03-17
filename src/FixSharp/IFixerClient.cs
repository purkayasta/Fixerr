// ---------------------------------------------------------------
// Copyright (c) Pritom Purkayasta All rights reserved.
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Fixerr.Models;

namespace Fixerr
{
    public interface IFixerClient
    {
        /// <summary>
        /// <para> The Fixer API comes with a separate currency conversion endpoint, which can be used to convert any amount from one currency to another. In order to convert currencies, 
        /// </para>
        /// <para>
        /// please use the API's convert endpoint, append the from and to parameters and set them to your preferred base and target currency codes.
        /// It is also possible to convert currencies using historical exchange rate data. 
        /// </para>
        /// <para>To do this, please also use the API's date parameter and set it to your preferred date. (format YYYY-MM-DD)</para>
        /// </summary>
        /// <param name="from">[required] The three-letter currency code of the currency you would like to convert from.</param>
        /// <param name="to">[required] The three-letter currency code of the currency you would like to convert to.</param>
        /// <param name="amount">[required] The amount to be converted.</param>
        /// <param name="historialDate">[optional] Specify a date (format YYYY-MM-DD) to use historical rates for this conversion.</param>
        /// <returns>CurrencyConvertResponse</returns>
        /// <exception cref="ArgumentException"></exception>
        ValueTask<CurrencyConvertResponse> GetConvertionAsync(string from, string to, int amount, string historialDate = null, string apiKey = null);

        /// <summary>
        /// Historical rates are available for most currencies all the way back to the year of 1999. 
        /// You can query the Fixer API for historical rates by appending a date (format YYYY-MM-DD) to the base URL.
        /// </summary>
        /// <param name="sourceDate">[required] Historic Data Only (YYYY-MM-DD)</param>
        /// <param name="baseCurrency">3 digit currency code! like => USD</param>
        /// <param name="symbols">Comma separated currency symbols code like => USD, EURO, JPY</param>
        /// <returns>HistoricRateResponse</returns>
        ValueTask<HistoricRateResponse> GetHistoricRateAsync(string sourceDate, string baseCurrency = null, string symbols = null, string apiKey = null);

        /// <summary>
        /// Depending on your subscription plan, the API's latest endpoint will 
        /// return real-time exchange rate data updated every 60 minutes, every 10 minutes or every 60 seconds.
        /// </summary>
        /// <param name="baseCurrency">Give the base currency, By Default base currency will be set to EUR by the API</param>
        /// <param name="symbols">Comma separated country's name</param>
        /// <returns>LatestRateResponse</returns>
        ValueTask<LatestRateResponse> GetLatestAsync(string baseCurrency = null, string symbols = null, string apiKey = null);

        /// <summary>
        /// The Fixer API comes with a constantly updated endpoint returning all available currencies. 
        /// To access this list, make a request to the API's symbols endpoint.
        /// </summary>
        /// <returns>SymbolResponse</returns>
        ValueTask<SymbolResponse> GetSymbolAsync(string apiKey = null);

        /// <summary>
        /// If supported by your subscription plan, the Fixer API's timeseries endpoint 
        /// lets you query the API for daily historical rates between two dates of your choice, with a maximum time frame of 365 days.
        /// </summary>
        /// <param name="startDate">string date format should be in YYYY-MM-DD</param>
        /// <param name="endDate">string date format should be in YYYY-MM-DD</param>
        /// <param name="baseCurrency">3 digit base currency code like => USD</param>
        /// <param name="symbols">symbols those are comma separated like => JPY, EURO, USD</param>
        /// <returns>TimeSeriesResponse</returns>
        ValueTask<TimeSeriesResponse> GetTimeSeriesAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);

        /// <summary>
        /// Using the Fixer API's fluctuation endpoint you will be able to retrieve information about how currencies fluctuate on a day-to-day basis. 
        /// To use this feature, simply append a start_date and end_date and choose which currencies (symbols) you would like to query the API for. 
        /// Please note that the maximum allowed timeframe is 365 days.
        /// </summary>
        /// <param name="startDate">string date format should be in YYYY-MM-DD</param>
        /// <param name="endDate">string date format should be in YYYY-MM-DD</param>
        /// <param name="baseCurrency">3 digit base currency code like => USD</param>
        /// <param name="symbols">symbols those are comma separated like => JPY, EURO, USD</param>
        /// <returns>FluctuationResponse</returns>
        ValueTask<FluctuationResponse> GetFluctuationAsync(string startDate, string endDate, string baseCurrency = null, string symbols = null, string apiKey = null);
    }
}