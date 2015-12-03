using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ParkingLotClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                //get parking spaces
                byte[] parkingSpacesResult = client.DownloadData("http://localhost:49964/api/parkingspaces");
                var parkingSpaces = ParseByteArrayToJToken(parkingSpacesResult);
                Console.WriteLine("Retrieved All Parking Spaces: {0}", parkingSpaces);

                //get hours on exit for vehicle with Id 1
                byte[] hoursResult = client.DownloadData(string.Format("http://localhost:49964/api/vehicles/{0}/hours",1));
                var hours = ParseByteArrayToJToken(hoursResult);
                Console.WriteLine("Exited Parking Lot, duration of stay is: {0}", hours);

                //get fees
                byte[] feesResult = client.DownloadData(string.Format("http://localhost:49964/api/parkingspaces/{0}/fees?hours={1}",
                                                                                                            parkingSpaces[1]["Id"], 
                                                                                                            hours));
                var fees = ParseByteArrayToJToken(feesResult);
                Console.WriteLine("Cost of Parking is: {0}", fees);

            }
            Console.ReadLine();
        }

        static JToken ParseByteArrayToJToken(byte[] data)
        {
            string jsonString = Encoding.UTF8.GetString(data);
            var result = JToken.Parse(jsonString);
            return result;
        }
    }
}