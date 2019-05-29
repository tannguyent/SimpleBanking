import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import store from '@/store'

Vue.use(VueAxios, axios)

export default function setup () {
  axios.interceptors.request.use(function (config) {
    const token = store.getters['oidcStore/oidcAccessToken']
    if (token) {
      config.headers.Authorization = `Bearer ${token}`
    }
    return config
  }, function (err) {
    return Promise.reject(err)
  })
}
