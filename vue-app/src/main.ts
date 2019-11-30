import './registerServiceWorker'
import './styles/main.scss'
import '@/styles/themes/index.css'

import Element from 'element-ui'
import { extend, localize } from 'vee-validate'
import en from 'vee-validate/dist/locale/en.json'
import * as rules from 'vee-validate/dist/rules'
import Vue from 'vue'

import App from './App.vue'
import router from './router'
import store from './store'

Vue.use(Element)
Vue.config.productionTip = false
rules
// install rules and localization
Object.keys(rules).forEach(rule => {
	extend(rule, rules[rule])
})

localize('en', en)

new Vue({
	router,
	store,
	render: h => h(App)
}).$mount('#app')
