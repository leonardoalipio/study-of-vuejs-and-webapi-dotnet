import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import bootstrapMain from './bootstrap-main'

Vue.config.productionTip = false
Vue.use(bootstrapMain)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
