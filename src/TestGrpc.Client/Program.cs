using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Client;
using TestGrpc.Shared.Time;

namespace TestGrpc.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var clock = channel.CreateGrpcService<ITimeService>();
            using var cancel = new CancellationTokenSource(TimeSpan.FromMinutes(1));
            
            var options = new CallOptions();
            try
            {
                await foreach (var time in clock.SubscribeAsync(new CallContext(options)).WithCancellation(cancel.Token))
                {
                    Console.WriteLine($"The time is now: {time.Time}");
                }
            }
            catch (RpcException ex) { Console.WriteLine(ex); }
            catch (OperationCanceledException) { }
        }
    }
}