export const calculatorsRoutes = {
  path: '/calculators',
  name: 'Calculators',
  component: () => import(/* webpackChunkName: "home" */ '@/views/calculators/CalculatorRoot.vue'),
  children: [
    {
      path: 'mortgage',
      name: 'MortgageCalculator',
      component: () => import(/* webpackChunkName: "home" */ '@/views/calculators/Mortgage.vue')
    },
    {
      path: 'investment',
      name: 'InvestmentCalculator',
      component: () => import(/* webpackChunkName: "home" */ '@/views/calculators/Investment.vue')
    }
  ]
}
