using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.ClientFactory;
using Microsoft.AspNetCore.Components;
using ProtoBuf.Grpc;
using TestGrpc.Shared.Time;

namespace TestGrpc.WasmClient.Pages
{
    public partial class Index
    {
        private readonly List<string> _testList = new();

        // [Inject]
        // public ITimeService TimeService { get; set; }
    
        // protected override async Task OnInitializedAsync()
        // {
        //     using var cancel = new CancellationTokenSource(TimeSpan.FromMinutes(1));
        //     var options = new CallOptions();
        //     try
        //     {
        //         //不支持流式处理。
        //         await foreach (var time in TimeService.SubscribeAsync(new CallContext(options)).WithCancellation(cancel.Token))
        //         {
        //             _testList.Add($"The time is now: {time.Time}");
        //         }
        //     }
        //     catch (RpcException ex) { Console.WriteLine(ex); }
        //     catch (OperationCanceledException) { }
        // }
    }
}