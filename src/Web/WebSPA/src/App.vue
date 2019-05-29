<template>
  <div id="app">
    <x-header></x-header>
    <div
      v-if="hasAccess"
      id="nav"
    >
      <router-link to="/">Home</router-link> |
      <router-link to="/transactionHistory">Transaction History</router-link>
    </div>
    <router-view/>
  </div>
</template>

<script>
import Vue from 'vue'
import { mapGetters } from 'vuex'
import Header from '@/components/Header'

export default {
  name: 'App',
  components: {
    XHeader: Header
  },
  computed: {
    ...mapGetters('oidcStore', [
      'oidcIsAuthenticated',
      'oidcIdToken'
    ]),
    hasAccess: function () {
      return this.oidcIsAuthenticated || this.$route.meta.isPublic
    }
  },
  methods: {
    userLoaded: function (e) {
      console.log('I am listening to the user loaded event in vuex-oidc', e.detail)
      const token = e.detail.id_token
      if (token) {
        Vue.prototype.$http.defaults.headers.common['Authorization'] = token
      }
    }
  },
  mounted () {
    window.addEventListener('vuexoidc:userLoaded', this.userLoaded)
  },
  destroyed () {
    window.removeEventListener('vuexoidc:userLoaded', this.userLoaded)
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
