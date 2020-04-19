namespace MortgageCalculator.ClientApp.src.models {
    export class MortgageResult {
        constructor(
            public mortgage: number,
            public property_taxes: number,
            public homeInsurance: number,
            public utilitiesCost: number,
            public associationDues: number,
            public total: number
        ) { }
    }
}
