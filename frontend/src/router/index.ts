import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'

import Home from '../views/Home.vue'
import NovoFornecedor from '../views/NovoFornecedor.vue'
import Produtos from '../views/Produtos.vue'
import FornecedorDetalhe from '../views/FornecedorDetalhe.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/fornecedor/:id',
    name: 'FornecedorDetalhe',
    component: FornecedorDetalhe,
    props: true
  },
  {
    path: '/novo-fornecedor',
    name: 'NovoFornecedor',
    component: NovoFornecedor
  },
  {
    path: '/produtos',
    name: 'Produtos',
    component: Produtos
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
