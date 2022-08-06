using System;
using CompoundCalculatorNS;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SpecFlowCoverage.Steps
{
    [Binding]
    public class SpecFlowFeature_Compoundtype_ComparisonSteps
    {
        private CompoundCalculator compoundCalculator = new CompoundCalculator();
        private int loanTerm;
        private double principal;
        private double interest;
        private bool includeTaxes;
        private decimal untaxedYearlyCompound;
        private decimal taxedYearlyCompound;
        private decimal untaxedQuarterlyCompound;
        private decimal untaxedMonthlyCompound;

        [Given(@"the loan term is (.*) year")]
        public void GivenTheLoanTermIsYear(int p0)
        {
            loanTerm = p0;
        }

        [Given(@"the principal is (.*) dollars")]
        public void GivenThePrincipalIsDollars(double p0)
        {
            principal = p0;
        }

        [Given(@"the interest is (.*)")]
        public void GivenTheInterestIs(double p0)
        {
            interest = p0;
        }

        [Given(@"the taxes are not included")]
        public void GivenTheTaxesAreNotIncluded()
        {
            includeTaxes = false;
        }

        [When(@"the untaxed monthly compound is calculated")]
        public void WhenTheUntaxedMonthlyCompoundIsCalculated()
        {
            untaxedMonthlyCompound = compoundCalculator.CountMonthlyCompoundInterest(loanTerm, principal, interest, includeTaxes);
        }

        [When(@"the untaxed quarterly compound is calculated")]
        public void WhenTheUntaxedQuarterlyCompoundIsCalculated()
        {
            untaxedQuarterlyCompound = compoundCalculator.CountQuarterlyCompoundInterest(loanTerm, principal, interest, includeTaxes);
        }

        [When(@"the untaxed yearly compound is calculated")]
        public void WhenTheUntaxedYearlyCompoundIsCalculated()
        {
            untaxedYearlyCompound = compoundCalculator.CountYearlyCompoundInterest(loanTerm, principal, interest, includeTaxes);
        }
        
        [Then(@"the untaxed monthly compound returns more interest than untaxed quarterly or untaxed yearly compound and the untaxed quarterly compound returns more interest than untaxed yearly compound")]
        public void ThenTheUntaxedMonthlyCompoundReturnsMoreInterestThanUntaxedQuarterlyOrUntaxedYearlyCompoundAndTheUntaxedQuarterlyCompoundReturnsMoreInterestThanUntaxedYearlyCompound()
        {
            untaxedMonthlyCompound.Should().BeGreaterThan(untaxedQuarterlyCompound);
            untaxedMonthlyCompound.Should().BeGreaterThan(untaxedYearlyCompound);
            untaxedQuarterlyCompound.Should().BeGreaterThan(untaxedYearlyCompound);
            Console.WriteLine($"{untaxedMonthlyCompound} > {untaxedQuarterlyCompound}");
            Console.WriteLine($"{untaxedMonthlyCompound} > {untaxedYearlyCompound}");
            Console.WriteLine($"{untaxedQuarterlyCompound} > {untaxedYearlyCompound}");
        }
        
        [Then(@"the taxes are included")]
        public void ThenTheTaxesAreIncluded()
        {
            includeTaxes = true;
        }

        [When(@"the taxed yearly compound is calculated")]
        public void WhenTheTaxedYearlyCompoundIsCalculated()
        {
            taxedYearlyCompound = compoundCalculator.CountYearlyCompoundInterest(loanTerm, principal, interest, includeTaxes);
        }

        [Then(@"taxed yearly compound returns less than non taxed yearly compound")]
        public void ThenTaxedYearlyCompoundReturnsLessThanNonTaxedYearlyCompound()
        {
            untaxedYearlyCompound.Should().BeGreaterThan(taxedYearlyCompound);
            Console.WriteLine($"{untaxedYearlyCompound} > {taxedYearlyCompound}");
        }
    }
}
