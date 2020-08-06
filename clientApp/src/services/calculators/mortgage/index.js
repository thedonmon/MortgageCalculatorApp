import axios from 'axios'

const BASE = 'api/calculator'

const urls = {
  calculate: `${BASE}/calculateMortgage`
}

export const MortgageCalculatorService = {
  calculate: (req) => axios.post(urls.calculate, req)
}
