using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tekton.Application.Contracts.Service;
using Tekton.Dominio;
 

namespace Tekton.Infraestructure.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> getDiscountProduct(int productId)
        {
            var urlservicediscount = _configuration.GetSection("urlservicediscount").Value;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{urlservicediscount}{productId}");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result=await response.Content.ReadAsStringAsync();

            var discount = JsonSerializer.Deserialize<DiscountProduct>(result.ToString());
            if (discount==null)
            {
                discount = new DiscountProduct();
                discount.Discount = 0;
                discount.ProductId = productId.ToString();
            }
            return discount.Discount;
        }
    }
}
