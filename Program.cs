using System;
using System.Collections.Generic;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("GE", "General Electric");
            stocks.Add("GOOG", "Google");

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            purchases.Add((ticker: "GM", shares: 5, price: 23.84));
            purchases.Add((ticker: "GM", shares: 7, price: 19.80));
            purchases.Add((ticker: "GM", shares: 5, price: 21.24));
            purchases.Add((ticker: "CAT", shares: 10, price: 3.64));
            purchases.Add((ticker: "CAT", shares: 150, price: 6.44));
            purchases.Add((ticker: "CAT", shares: 22, price: 4.07));
            purchases.Add((ticker: "GE", shares: 22, price: 14.03));
            purchases.Add((ticker: "GE", shares: 200, price: 8.22));
            purchases.Add((ticker: "GE", shares: 70, price: 25.06));
            purchases.Add((ticker: "GOOG", shares: 40, price: 105.83));
            purchases.Add((ticker: "GOOG", shares: 5, price: 120.74));
            purchases.Add((ticker: "GOOG", shares: 20, price: 102.83));
            purchases.Add((ticker: "GOOG", shares: 70, price: 108.54));

            Dictionary<string, double> totalOwnership = new Dictionary<string, double>();


            // Iterate over the purchases and update the valuation for each stock
            foreach ((string ticker, int shares, double price) purchase in purchases)
            {
                foreach (KeyValuePair<string, string> stock in stocks)
                {
                    // Does the company name key already exist in the report dictionary?
                    if (stock.Key.Contains(purchase.ticker))
                    {

                        // If it does, update the total valuation
                        if (totalOwnership.ContainsKey(stock.Value))
                        {
                            totalOwnership[stock.Value] += purchase.shares * purchase.price;
                        }
                        // If not, add the new key and set its value
                        else
                        {
                            totalOwnership.Add(stock.Value, (purchase.shares * purchase.price));
                        }
                    }

                }
            }
            foreach (KeyValuePair<string, double> report in totalOwnership) {
                Console.WriteLine($"{report.Key} ${report.Value:f2}");

            }
        }

    }
}

