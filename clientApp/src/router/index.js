import Vue from 'vue'
import VueRouter from 'vue-router'

import { calculatorsRoutes } from '@/router/calculators'

Vue.use(VueRouter)

const routes = [
  {
    path: '/Home',
    name: 'Home',
    component: () => import(/* webpackChunkName: "home" */ '../views/Home.vue')
  },
  {
    path: '/about',
    name: 'About',
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  calculatorsRoutes
]

const router = new VueRouter({
  routes
})

export default router
