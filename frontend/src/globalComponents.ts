import { VueConstructor } from 'vue'

/**
 * You can register global components here and use them as a plugin in your main Vue instance
 */

import NavBar from '@/layout/NavBar.vue'
import SideBar from '@/layout/SideBar/SideBar.vue'
import Footer from '@/layout/Footer.vue'
import Content from '@/layout/Content.vue'

const GlobalComponents = {
  install (Vue: VueConstructor<Vue>) {
    Vue.component('NavBar', NavBar)
    Vue.component('SideBar', SideBar)
    Vue.component('Content', Content)
    Vue.component('Footer', Footer)
  }
}

export default GlobalComponents