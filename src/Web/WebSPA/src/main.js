import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

// ui library
import './element-ui'

// import http
import axiosSetup from './axios'
axiosSetup()

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
