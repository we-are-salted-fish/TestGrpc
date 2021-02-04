using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;
using TestGrpc.Shared.Time;

namespace TestGrpc.WasmClient.Pages
{
    public partial class Index
    {
        private readonly List<string> _testList = new();
    
        protected override async Task OnInitializedAsync()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });
        
            var clock = channel.CreateGrpcService<ITimeService>();
            using var cancel = new CancellationTokenSource(TimeSpan.FromMinutes(1));
            var options = new CallOptions();
            try
            {
                //不支持流式处理。
                await foreach (var time in clock.SubscribeAsync(new CallContext(options)).WithCancellation(cancel.Token))
                {
                    _testList.Add($"The time is now: {time.Time}");
                }
            }
            catch (RpcException ex) { Console.WriteLine(ex); }
            catch (OperationCanceledException) { }
        }
    }
}