using HizliGeliyoEcom.Entities.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace HizliGeliyoEcom.DataAccess.Context
{
    public class SeedData
    {
        public static async void Seed(IApplicationBuilder app)
        {
            using var servicesScope = app.ApplicationServices.CreateScope();
            ProjectContext context = servicesScope.ServiceProvider.GetService<ProjectContext>();

            context.Database.Migrate();


            if (!context.Products.Any())
            {
                string url = "https://fakestoreapi.com/products";

                using (var client = new HttpClient())
                {

                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();

                            Product[] products = JsonConvert.DeserializeObject<Product[]>(data);

                            foreach (var item in products)
                            {
                                await context.AddAsync(new Product
                                {
                                    
                                    Title = item.Title,
                                    Price = item.Price,
                                    Description = item.Description,
                                    Category = item.Category,
                                    Image = item.Image,
                                    Status = Core.Enum.Status.Active,
                                });
                            }
                        }
                    }

                }
            }

            await context.SaveChangesAsync();

        }

    }
}

#region Deneme
//var response = client.GetStringAsync(url);

//string jsonStr =File.ReadAllText(response);

//jsonStr = jsonStr.Replace("\\", "");
//jsonStr = jsonStr.Replace("\"[", "[");
//jsonStr = jsonStr.Replace("]\"", "]");

//var ser = JsonConvert.DeserializeObject<Product[]>(jsonStr);

//foreach (var item in ser)
//{
//    context.Add(new Product
//    {
//        ApiID = item.ApiID,
//        Title = item.Title,
//        Price = item.Price,
//        Description = item.Description,
//        Category = item.Category,
//        Image = item.Image,
//        Status = Core.Enum.Status.Active
//    });
//} 
#endregion