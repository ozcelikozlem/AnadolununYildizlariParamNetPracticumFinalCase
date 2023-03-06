using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using WebApi.Entities;
using Xunit;

namespace WebApi.IntegrationTests.Application.MeasureOperations
{
    public class OnlineStoreIntegrationTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/measures");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                
            }
        }

        [Fact]
        public async Task Test_Post()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("/measures"
                , new StringContent(
                    JsonConvert.SerializeObject( new Measure(){Title="metre"}), Encoding.UTF8,"application/json" ));

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                
            }
        }
    }
}
