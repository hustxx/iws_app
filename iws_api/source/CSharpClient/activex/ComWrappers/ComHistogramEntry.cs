﻿/* Copyright (C) 2018 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true)]
    public interface IHistogramEntry
    {
        double Price { get; set; }
        long Size { get; set; }
    }

    [ComVisible(true)]
    public class ComHistogramEntry : ComWrapper<IBApi.HistogramEntry>, IHistogramEntry
    {
        double IHistogramEntry.Price { get { return data.Price; } set { data.Price = value; } }
        long IHistogramEntry.Size { get { return data.Size; } set { data.Size = value; } }

        public static explicit operator IBApi.HistogramEntry(ComHistogramEntry ctv)
        {
            return ctv.ConvertTo();
        }

        public static explicit operator ComHistogramEntry(IBApi.HistogramEntry tv)
        {
            return new ComHistogramEntry().ConvertFrom(tv) as ComHistogramEntry;
        }
    }
}
