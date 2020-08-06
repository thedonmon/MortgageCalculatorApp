import axios from 'axios'

const BASE = 'https://mortgagecalculator20200805210321.azurewebsites.net'
const API = 'api/calculator'

const urls = {
  calculate: `${BASE}/${API}/calculateMortgage`
}

export const MortgageCalculatorService = {
  calculate: (req) => axios.post(urls.calculate, req)
}
