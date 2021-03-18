import { VueConstructor } from 'vue'

import GlobalComponents from './globalComponents'
import GlobalDirectives from './globalDirectives'

import 'bootstrap/dist/css/bootstrap.css'
import '@fortawesome/fontawesome-free/css/all.css'

import '@/assets/css/style.css'

export default {
	install (Vue: VueConstructor<Vue>) {
        Vue.use(GlobalComponents)
        Vue.use(GlobalDirectives)
	}
}