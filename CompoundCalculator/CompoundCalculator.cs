using System;

namespace CompoundCalculatorNS
{
    public class CompoundCalculator
    {
        private readonly int yearlyPaymentFrequency = 1;
        private readonly int quarterlyPaymentFrequency = 4;
        private readonly int monthlyPaymentFrequency = 12;

        private static void ValidateParameters(int loanTerm, double principal, double interest)
        {
            if (loanTerm < 1)
            {
                throw new ArgumentOutOfRangeException("Loan term must be at least 1 (year)");
            }

            if (principal < 1)
            {
                throw new ArgumentOutOfRangeException("The loan sum must be higher than 0");
            }

            if (interest > 1 || interest <= 0)
            {
                throw new ArgumentOutOfRangeException("The interest must be in range from 0.0 to 1.0 included (meaning 5% should be set as 0.05");
            }
        }

        static private decimal CountCompoundInterest(int loanTerm, int anualPaymentFrequency, double principal, double interest, bool includeTaxes)
        {
            double income;
            double futureValue = principal;
            double anualPaymentFrequencyD = Convert.ToDouble(anualPaymentFrequency);

            for (int i = 0; i < loanTerm; i++)
            {
                for (int y = 0; y < anualPaymentFrequency; y++)
                {
                    income = futureValue * interest * (1.0 / anualPaymentFrequencyD);
                    if (includeTaxes)
                    {
                        income *= 0.805;
                    }
                    futureValue += income;
                }
            }
            return Math.Round(Convert.ToDecimal(futureValue), 2);
        }

        public decimal CountYearlyCompoundInterest(int loanTerm, double principal, double interest, bool includeTaxes)
        {
            ValidateParameters(loanTerm, principal, interest);
            return CountCompoundInterest(loanTerm, yearlyPaymentFrequency, principal, interest, includeTaxes);
        }

        public decimal CountQuarterlyCompoundInterest(int loanTerm, double principal, double interest, bool includeTaxes)
        {
            ValidateParameters(loanTerm, principal, interest);
            return CountCompoundInterest(loanTerm, quarterlyPaymentFrequency, principal, interest, includeTaxes);
        }

        public decimal CountMonthlyCompoundInterest(int loanTerm, double principal, double interest, bool includeTaxes)
        {
            ValidateParameters(loanTerm, principal, interest);
            return CountCompoundInterest(loanTerm, monthlyPaymentFrequency, principal, interest, includeTaxes);
        }
    }
}
