<template>
  <div v-if="oidcIsAuthenticated">
    Signed in as {{ oidcUser.name }}
    <button @click="signOutOidc">Sign out</button>
  </div>
  <div v-else>
    <button @click="authenticateOidc">Sign In</button>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'Header',
  computed: {
    ...mapGetters('oidcStore', [
      'oidcIsAuthenticated',
      'oidcAuthenticationIsChecked',
      'oidcUser',
      'oidcIdToken',
      'oidcIdTokenExp'
    ])
  },
  methods: {
    ...mapActions('oidcStore', [
      'signOutOidc',
      'authenticateOidc'
    ])
  }
}
</script>
