using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.SystemCenter.Test.Loader
{
    class Averager
    {
        private static double dRunningTotal = 0;
        private static double dSampleCount = 0;

        public double Average
        {
            get
            {
                if (dRunningTotal > 0 &&
                    dSampleCount > 0)
                {
                    return (dRunningTotal / dSampleCount);
                }
                else
                {
                    return 0;
                }
            }
        }

        public double SampleCount
        {
            get { return dSampleCount; }
        }

        public Averager()
        {

        }

        public void AddSample(double dSample)
        {
            dRunningTotal = dRunningTotal + dSample;
            dSampleCount++;
            return;
        }
    }
}
