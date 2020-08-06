using System;
using System.Collections.Generic;
using System.Text;

namespace MotgageCalculator.Domain.Calculators
{
    public static class FinancialFunctions
    {
        public static double PMT(double r, int nper, double pv, double fv, int type)
        {
            double pmt;
            if (nper == 0)
                pmt = 0;
            else if (r == 0)
                pmt = (fv - pv) / nper;
            else
                pmt = r / (Math.Pow(1 + r, nper) - 1)
                    * -(pv * Math.Pow(1 + r, nper) + fv);

            if (type == 1) pmt /= (1 + r);

            return pmt;
        }

        public static double FV(double r, int nper, double c, double pv, int type)
        {
            double c1 = c;

            if (type == 1)
            {
                c1 = c1 * (1 + r);
            }

            double fv;

            if (nper == 0)
                fv = -pv;
            else if (r == 0)
                fv = -(pv + (nper * c1));
            else
                fv = -(c1 * (Math.Pow(1 + r, nper) - 1) / r + pv
                    * Math.Pow(1 + r, nper));

            return fv;
        }
        public static double IPMT(double r, int per, int nper, double pv, double fv, int type)
        {
            double pmt = PMT(r, nper, pv, fv, type);
            double fv1 = FV(r, per - 1, pmt, pv, type);
            double ipmt = fv1 * r;

            if (type == 1) ipmt /= (1 + r);

            return ipmt;
        }
        public static double PPMT(double r, int per, int nper, double pv, double fv, int type)
        {
            double pmt = PMT(r, nper, pv, fv, type);
            double fv1 = FV(r, per - 1, pmt, pv, type);
            double ipmt = fv1 * r;

            if (type == 1) ipmt /= (1 + r);

            return pmt - ipmt;
        }
    }
}
