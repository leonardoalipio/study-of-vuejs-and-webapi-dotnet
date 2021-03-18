import Vue, { VueConstructor } from 'vue'

import { mask } from 'vue-the-mask'

const GlobalComponents = {
  install (Vue: VueConstructor<Vue>) {
    Vue.directive('mask', mask)
  }
}

export default GlobalComponents