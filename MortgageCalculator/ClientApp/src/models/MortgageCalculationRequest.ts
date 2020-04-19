
namespace MortgageCalculator.ClientApp.src.models {
    export class MortgageCalculationRequest {
        constructor(
            public purchase: Purchase,
            public mortgage: Mortgage,
            public extras: Extras,
            public requestId : Guid = Guid.newGuid();
        ) { }
    }
}
export class Purchase {
    constructor(
        public purchase_price: number,
        public down_payment_percentage: number
    ) { }
}
export class Mortgage {
    constructor(
        public interest_rate: number,
        public loan_amortization_term_mo: number,
    ) { }
}
export class Extras {
    constructor(
        public property_taxes: number,
        public home_insurance: number,
        public utilities: Utility[],
        public hoa_dues: number
    ) { }
}
export class Utility {
    constructor(
        public name: string,
        public cost: number,
    ) { }
}
export class Guid {
    static newGuid() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0,
                v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }
}
