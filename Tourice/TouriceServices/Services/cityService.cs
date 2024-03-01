using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TouriceDatabases.Modals;
using TouriceServices.IServices;

namespace TouriceServices.Services
{
    public class cityService:ICityService
    {
        public async Task<List<tblCity>> getCityList()
        {
            try
            {
                List<tblCity> result = new List<tblCity>();
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://api.countrystatecity.in/v1/countries/IN/cities";
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("X-CSCAPI-KEY", "cDc5M1BQV0pDR2lCQUx5eVlIZXlObUdaY2NZRVpoREpZakNObWpKVA== ");
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Check if the request was successful (status code 200-299)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and display the content
                        string content = await response.Content.ReadAsStringAsync();
                      result = JsonConvert.DeserializeObject<List<tblCity>>(content);

                        Console.WriteLine(content);
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                    

                };
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
