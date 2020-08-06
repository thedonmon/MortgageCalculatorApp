<template>
  <div class="mortgage-calculator md-layout">
    <div class="md-layout-item md-size-100">
      <h1>Mortgage Calculator</h1>
      <p>SOME INFORMATION ABOUT THE CALCULATOR</p>
    </div>
    <div class="md-layout-item md-small-size-33 md-small-medium-33 md-large-size-33 md-xlarge-size-33 md-xsmall-size-100 mortgage-calculator__inputs">
      <!-- PURCHASE -->
      <md-field>
        <label>Purchase Price</label>
        <span class="md-prefix">$</span>
        <md-input v-model.number="purchasePrice"></md-input>
      </md-field>
      <md-field>
        <label>Down Payment Percentage</label>
        <md-input v-model.number="downPaymentPercentage"></md-input>
        <span class="md-suffix">%</span>
      </md-field>

      <!-- MORTGAGE -->
      <md-field>
        <label>Interest Rate</label>
        <md-input v-model.number="interestRate"></md-input>
        <span class="md-suffix">%</span>
      </md-field>
      <md-field>
        <label>Loan Amortization Term</label>
        <md-input v-model.number="loanTerm"></md-input>
        <span class="md-suffix">mo</span>
      </md-field>

      <!-- EXTRAS -->
      <md-field>
        <label>Property Taxes</label>
        <span class="md-prefix">$</span>
        <md-input v-model.number="propertyTaxes"></md-input>
      </md-field>
      <md-field>
        <label>Home Insurance</label>
        <span class="md-prefix">$</span>
        <md-input v-model.number="homeInsuranceAnnual"></md-input>
        <span class="md-suffix">/yr</span>
      </md-field>
      <md-field>
        <label>HOA Dues</label>
        <span class="md-prefix">$</span>
        <md-input v-model.number="hoaDues"></md-input>
        <span class="md-suffix">/mo</span>
      </md-field>

      <div class="md-layout md-alignment-center-right">
        <label class="md-layout-item md-size-100">Utilities</label>
        <div class="md-layout-item md-size-100">
          <div
            v-for="utility in utilities"
            :key="utility.id"
          >
            <div class="md-layout md-alignment-center-space-between">
              <div class="md-layout-item md-size-60 md-small-size-100">
                <md-field>
                  <label>Name</label>
                  <md-input v-model="utility.name"></md-input>
                </md-field>
              </div>
              <div class="md-layout-item md-size-20 md-small-size-100">
                <md-field>
                  <label>Cost</label>
                  <span class="md-prefix">$</span>
                  <md-input v-model.number="utility.cost"></md-input>
                </md-field>
              </div>
              <div class="md-layout-item md-size-10 md-small-size-100 md-layout md-alignment-center-right">
                <md-button :disabled="!moreThanOneUtility" class="md-icon-button md-raised md-dense" @click="() => removeUtility(utility.id)">
                  <md-icon>remove</md-icon>
                </md-button>
              </div>
            </div>
          </div>
        </div>
        <md-button class="md-button md-raised md-dense" @click="addUtility">
          <md-icon>add</md-icon>
          add utility
        </md-button>
      </div>

    </div>
    <div class="
            md-layout
            md-layout-item 
            md-xsmall-size-100 
            mortgage-calculator__results">
      <div class="mortgage-calculator__result-container">
        <md-button class="md-raised md-primary mortgage-calculator__action" @click="calculateMortgage">Calculate</md-button>
        <mortgage-result
          v-if="results"
          :mortgage="results.mortgage"
          :propertyTaxes="results.propertyTaxes"
          :homeInsurance="results.homeInsurance"
          :utilitiesCost="results.utilitiesCost"
          :associationDues="results.associationDues"
          :total="results.total"
        />
      </div>
    </div>
  </div>
</template>

<script>
import MortgageResult from '@/components/charts/mortgage/Result.vue'

import { mapCalculateMortgageRequest, mapCalculateMortgageResponse } from '@/mappers/calculators/mortgage'
import { MortgageCalculatorService } from '@/services/calculators/mortgage'

export default {
  name: 'Mortgage',
  components: {
    MortgageResult
  },
  mixins: [],
  props: {},
  data: () => ({
    purchasePrice: 0,
    downPaymentPercentage: 0,
    interestRate: 0,
    loanTerm: 0,
    propertyTaxes: 0,
    homeInsuranceAnnual: 0,
    hoaDues: 0,
    utilities: [
      { id: 0, name: '', cost: 0 }
    ],
    utilityId: 0,
    results: null
  }),
  created () {},
  mounted () {},
  updated () {},
  destroyed () {},
  watch: {},
  computed: {
    moreThanOneUtility () {
      return this.utilities.length > 1
    }
  },
  methods: {
    addUtility () {
      this.utilities.push({ id: ++this.utilityId, name: '', cost: 0 })
    },
    removeUtility (id) {
      if (!this.moreThanOneUtility) return
      this.utilities.splice(this.utilities.findIndex(u => u.id == id), 1)
    },
    updateUtilityName (id, name) {
      const utilityIndex = this.utilities.findIndex(u => u.id == id)
      const utility = this.utilities[utilityIndex]
      utility.name = name
      this.utilities.splice(utilityIndex, 1, utility)
    },
    updateUtilityCost (id, cost) {
      const utilityIndex = this.utilities.findIndex(u => u.id == id)
      const utility = this.utilities[utilityIndex]
      utility.cost = cost
      this.utilities.splice(utilityIndex, 1, utility)
    },
    async calculateMortgage () {
      const request = {
        purchasePrice: this.purchasePrice,
        downPaymentPercentage: this.downPaymentPercentage,
        interestRate: this.interestRate,
        loanTerm: this.loanTerm,
        propertyTaxes: this.propertyTaxes,
        homeInsuranceAnnual: this.homeInsuranceAnnual,
        hoaDues: this.hoaDues,
        utilities: this.utilities
      }
      try {
        const res = await MortgageCalculatorService.calculate(mapCalculateMortgageRequest(request))
        const mapped = mapCalculateMortgageResponse(res.data.data)
        this.results = mapped
      } catch (ex) {
        console.log(ex)
      }
    }
  },
  directives: {},
  filters: {},
}
</script>

<style lang="scss">
.mortgage-calculator {
  &__result-container {
    width: 100%;
    display: flex;
    flex-direction: column;
  }
  &__action {
    align-self: flex-end;
  }
}
</style>
