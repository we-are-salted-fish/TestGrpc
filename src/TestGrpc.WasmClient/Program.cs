using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client.Web;
using ProtoBuf.Grpc.ClientFactory;
using TestGrpc.Shared.Time;

namespace TestGrpc.WasmClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services
                .AddCodeFirstGrpcClient<ITimeService>((services, options) =>
                {
                    options.Address = new Uri("https://localhost:5001");
                })
                .ConfigurePrimaryHttpMessageHandler(
                    () => new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler()));
            
            await builder.Build().RunAsync();
        }
    }
}
