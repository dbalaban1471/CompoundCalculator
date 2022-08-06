Feature: SpecFlowFeature_compoundtype_comparison
	This case must ensure that monthly compound	returns more
	interest than quarterly or yearly compound and quarterly compound 
	returns more interest than yearly compound
	Also this case ensures taxed interest returns
	will be less than untaxed

@payment_frequency_comparison
Scenario: Compare yearly to quarterly to monthly, feature taxes
	Given the loan term is 1 year
	And the principal is 10000.0 dollars
	And the interest is 0.2
	And the taxes are not included
	When the untaxed monthly compound is calculated
	When the untaxed quarterly compound is calculated
	When the untaxed yearly compound is calculated
	Then the untaxed monthly compound returns more interest than untaxed quarterly or untaxed yearly compound and the untaxed quarterly compound returns more interest than untaxed yearly compound
	And the taxes are included
	When the taxed yearly compound is calculated
	Then taxed yearly compound returns less than non taxed yearly compound