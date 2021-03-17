import Vue, { VueConstructor } from 'vue'

import GlobalComponents from './globalComponents'

import 'bootstrap/dist/css/bootstrap.css'
import '@fortawesome/fontawesome-free/css/all.css'

export default {
	install (Vue: VueConstructor<Vue>) {
        Vue.use(GlobalComponents)
	}
}