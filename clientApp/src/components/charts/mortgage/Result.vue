<template>
  <div id="mortgage-result"></div>
</template>

<script>
import { createChart } from './pieChart'

export default {
  name: 'MortgageResult',
  components: {},
  mixins: [],
  props: {
    mortgage: {
      type: Number,
      required: true
    },
    propertyTaxes: {
      type: Number,
      required: true
    },
    homeInsurance: {
      type: Number,
      required: true
    },
    utilitiesCost: {
      type: Number,
      required: true
    },
    associationDues: {
      type: Number,
      required: true
    }
  },
  data: () => ({}),
  created () {},
  mounted () {
    const data = {
      total: 1000000000,
      breakdown: [
        this.createDataPoint('mortgage', 'Mortgage'),
        this.createDataPoint('propertyTaxes', 'Property Taxes'),
        this.createDataPoint('homeInsurance', 'Home Insurance'),
        this.createDataPoint('utilitiesCost', 'Utilities Cost'),
        this.createDataPoint('associationDues', 'Association Dues')
      ]
    }
    createChart(this.$el, data)
  },
  updated () {},
  destroyed () {},
  watch: {},
  computed: {},
  methods: {
    createDataPoint (property, label) {
      return {
        label,
        value: this[property]
      }
    }
  },
  directives: {},
  filters: {},
}
</script>

<style lang="scss">
#mortgage-result{
  display: flex;
    justify-content: center;
    align-items: center;
}
/* Add shadow effect to chart. If you don't like it, get rid of it. */
svg {
  -webkit-filter: drop-shadow( 0px 3px 3px rgba(0,0,0,.3) );
  filter: drop-shadow( 0px 3px 3px rgba(0,0,0,.25) );
  width: 100%;
}

.label {
  font-weight: 100;
  fill: grey;
}
.cost {
  font-weight: 600;
}

// /*Styling for the lines connecting the labels to the slices*/
// polyline{
//     opacity: .3;
//     stroke: black;
//     stroke-width: 2px;
//     fill: none;
// }

/* Make the percentage on the text labels bold*/
// .labelName tspan {
//     font-style: normal;
//     font-weight: 700;
// }

// /* In biology we generally italicise species names. */
// .labelName {
//     font-size: 0.9em;
//     font-style: italic;
// }
</style>
