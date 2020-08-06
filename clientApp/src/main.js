import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

import DesignSystem from '@/plugins/design-system.js'

Vue.config.productionTip = false

Vue.use(DesignSystem)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
