import Vue from 'vue'
import Vuex from 'vuex'
import routeLoading from './modules/route'
import config from './modules/global-config'
import oidc from './modules/oidc'
import user from './modules/user'

Vue.use(Vuex)

const store = new Vuex.Store({
  strict: process.env.NODE_ENV !== 'production',
  modules: {
    config,
    user,
    routeLoading,
    oidcStore: oidc
  }
})

export default store
