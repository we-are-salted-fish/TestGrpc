using System.Collections.Generic;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace TestGrpc.Shared.Time
{
    [Service]
    public interface ITimeService
    {
        [Operation]
        IAsyncEnumerable<TimeResult> SubscribeAsync(CallContext context = default);
    }
}