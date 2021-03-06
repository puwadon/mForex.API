﻿using System;
using ProtoBuf;

namespace mForex.API.Data
{
    [ProtoContract]
    public struct Candle
    {
        [ProtoMember(1, IsRequired = true)]
        public double Open { get; set; }

        [ProtoMember(2, IsRequired = true)]
        public double Close { get; set; }

        [ProtoMember(3, IsRequired = true)]
        public double Low { get; set; }

        [ProtoMember(4, IsRequired = true)]
        public double High { get; set; }

        [ProtoMember(5, IsRequired = true)]
        public int Volume { get; set; }

        [ProtoMember(6, IsRequired = true)]
        public DateTime Time { get; set; }

        public Candle(double open, double close, double low,
            double high, int volume, DateTime time)
            : this()
        {
            Open = open;
            Close = close;
            Low = low;
            High = high;
            Volume = volume;
            Time = time;
        }

        public Candle(int digits, int openInPips, int closeDelta, int lowDelta,
            int highDelta, int volume, DateTime time)
            : this()
        {
            double multiply = Math.Pow(0.1, digits);

            Open = multiply * openInPips;
            Close = multiply * (openInPips + closeDelta);
            High = multiply * (openInPips + highDelta);
            Low = multiply * (openInPips + lowDelta);

            Volume = volume;
            Time = time;
        }
    }
}
