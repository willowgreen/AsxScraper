using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace AsxScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "AsxScraper";

            List<DataPoint> DataPoints = new List<DataPoint>();

            string list = new WebClient().DownloadString("https://www.asx.com.au/asx/research/ASXListedCompanies.csv");

            List<string> codes = new List<string>();

            // TODO IDictionary<string, string> companies = new Dictionary<string, string>(); // list.Split(Environment.NewLine).Length;

            using (StringReader reader = new StringReader(list))
            {
                int counter = 1;
                string line = string.Empty;
                do
                {
                    line = reader.ReadLine();
                    if (counter > 3 && line != null) // 3 lines of 'headings'
                    {
                        line = line.Replace("\"", "");
                        
                        string[] la = new string[3]; // [0] Company name, [1] ASX code, [2] GICS industry group
                        la = line.Split(",".ToCharArray());

                        if (la[1].Length == 3) // 3 letter ticker codes
                            codes.Add(la[1]);
                        else // for example "XYZ Capital, Inc."
                            codes.Add(la[2]);

                        // TODO if line.Contains("GICS industry group") ....
                        // TODO list.Split(Environment.NewLine.ToCharArray).Length
                    }
                    counter++;
                } while (line != null);
            }

            WebClient wc = new WebClient();

            foreach (string code in codes)
            {
                JObject data;
                try
                {
                    data = JObject.Parse(wc.DownloadString("https://www.asx.com.au/asx/1/share/" + code));
                    DataPoint coy = new DataPoint();

                    coy.Code = (data["code"] ?? "ERROR").ToString();
                    coy.IsinCode = (data["isin_code"] ?? "ERROR").ToString();
                    coy.DescFull = (data["desc_full"] ?? "Error encountered").ToString();
                    coy.LastPrice = float.Parse((data["last_price"] ?? "0").ToString());
                    coy.OpenPrice = float.Parse((data["open_price"] ?? "0").ToString());
                    coy.DayHighPrice = float.Parse((data["day_high_price"] ?? "0").ToString());
                    coy.DayLowPrice = float.Parse((data["day_low_price"] ?? "0").ToString());
                    coy.ChangePrice = float.Parse((data["change_price"] ?? "0").ToString());
                    coy.ChangeInPercent = (data["change_in_percent"] ?? "0").ToString();
                    coy.Volume = long.Parse((data["volume"] ?? "0").ToString());
                    coy.BidPrice = float.Parse((data["bid_price"] ?? "0").ToString());
                    coy.OfferPrice = float.Parse((data["offer_price"] ?? "0").ToString());
                    coy.PreviousClosePrice = float.Parse((data["previous_close_price"] ?? "0").ToString());
                    coy.PreviousDayPercentageChange = (data["previous_day_percentage_change"] ?? "0").ToString();
                    coy.YearHighPrice = float.Parse((data["year_high_price"] ?? "0").ToString());
                    coy.LastTradeDate = DateTime.Parse((data["last_trade_date"] ?? "2000-01-01T00:00:00+1000").ToString());
                    coy.YearHighDate = DateTime.Parse((data["year_high_date"] ?? "2000-01-01T00:00:00+1000").ToString());
                    coy.YearLowPrice = float.Parse((data["year_low_price"] ?? "0").ToString());
                    coy.YearLowDate = DateTime.Parse((data["year_low_date"] ?? "2000-01-01T00:00:00+1000").ToString());
                    coy.YearOpenPrice = float.Parse((data["year_open_price"] ?? "0").ToString());
                    coy.YearOpenDate = DateTime.Parse((data["year_open_date"] ?? "2000-01-01T00:00:00+1000").ToString());
                    coy.YearChangePrice = float.Parse((data["year_change_price"] ?? "0").ToString());
                    coy.YearChangeInPercentage = (data["year_change_in_percentage"] ?? "0").ToString();
                    coy.PE = float.Parse((data["pe"] ?? "0").ToString());
                    coy.EPS = float.Parse((data["eps"] ?? "0").ToString());
                    coy.AverageDailyVolume = long.Parse((data["average_daily_volume"] ?? "0").ToString());
                    coy.AnnualDividendYield = float.Parse((data["annual_dividend_yield"] ?? "0").ToString());
                    coy.MarketCap = double.Parse((data["market_cap"] ?? "0").ToString());
                    coy.NumberOfShares = long.Parse((data["number_of_shares"] ?? "0").ToString());
                    coy.Suspended = bool.Parse((data["suspended"] ?? "false").ToString());
                    DataPoints.Add(coy);
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        var response = ex.Response as HttpWebResponse;
                        if (response != null && (int)response.StatusCode == 404)
                        {
                            // TODO 404 - data not available
                        }
                    }
                }
            }

            foreach (DataPoint dp in DataPoints)
            {
                Console.WriteLine(dp.Code + " " + dp.LastPrice);
            }

            Console.Write("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
