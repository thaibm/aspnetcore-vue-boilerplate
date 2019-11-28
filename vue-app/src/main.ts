import './registerServiceWorker'
import './styles/main.scss'
import '@/styles/themes/index.css'

import Element from 'element-ui'
import Vue from 'vue'

import App from './App.vue'
import router from './router'
import store from './store'

Vue.use(Element)
Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
