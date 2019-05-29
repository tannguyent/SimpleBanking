<template>
  <div v-if="oidcIsAuthenticated">
    Signed in as {{ oidcUser.email }}
    <button @click="signOutOidc">Sign out</button>
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
      'signOutOidc'
    ])
  }
}
</script>
