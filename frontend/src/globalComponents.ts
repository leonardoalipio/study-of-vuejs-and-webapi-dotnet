import Vue, { VueConstructor } from 'vue'

/**
 * You can register global components here and use them as a plugin in your main Vue instance
 */

import NavBar from '@/layout/NavBar.vue'
import SideBar from '@/layout/SideBar.vue'

const GlobalComponents = {
  install (Vue: VueConstructor<Vue>) {
    Vue.component('NavBar', NavBar)
    Vue.component('SideBar', SideBar)
  }
}

export default GlobalComponents