<template>
  <div v-if="oidcIsAuthenticated">
    Signed in as {{ oidcUser.name }}
    <el-button @click="signOutOidc">Sign out</el-button>
  </div>
  <div v-else>
    <el-button @click="authenticateOidc">Sign In</el-button>
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
