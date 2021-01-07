using System;
using ProtoBuf;

namespace TestGrpc.Shared.Time
{
    [ProtoContract]
    public class TimeResult
    {
        [ProtoMember(1, DataFormat = DataFormat.WellKnown)]
        public DateTime Time { get; set; }

        [ProtoMember(2)]
        public Guid Id { get; set; }
    }
}