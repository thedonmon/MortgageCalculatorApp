import { MdButton, MdApp, MdTabs, MdContent, MdIcon, MdToolbar, MdField, MdList } from 'vue-material/dist/components'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'

const components = [MdButton, MdApp, MdTabs, MdContent, MdIcon, MdToolbar, MdField, MdList]

export default {
  install (Vue) {
    components.forEach(component => Vue.use(component))
  }
}