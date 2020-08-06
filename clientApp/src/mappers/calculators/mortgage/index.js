const mapUtilitiesRequest = ({
  name,
  cost
}) => ({
  name,
  cost
})

export const mapCalculateMortgageRequest = ({
  purchasePrice,
  downPaymentPercentage,
  interestRate,
  loanTerm,
  propertyTaxes,
  homeInsuranceAnnual,
  hoaDues,
  utilities
}) => ({
  Purchase: {
    purchase_price: purchasePrice,
    down_payment_percentage: downPaymentPercentage
  },
  Mortgage: {
    interest_rate: interestRate,
    loan_amortization_term_mo: loanTerm
  },
  Extras: {
    property_taxes: propertyTaxes,
    home_insurance: homeInsuranceAnnual,
    utilities: utilities.map(mapUtilitiesRequest),
    hoa_dues: hoaDues
  }
})

export const mapCalculateMortgageResponse = ({
  mortgage,
  property_taxes,
  home_insurance,
  utilities_cost,
  association_dues,
  total
}) => ({
  mortgage,
  propertyTaxes: property_taxes,
  homeInsurance: home_insurance,
  utilitiesCost: utilities_cost,
  associationDues: association_dues
})
