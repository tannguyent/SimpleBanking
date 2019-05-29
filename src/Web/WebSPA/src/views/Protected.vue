<template>
  <div
    v-if="oidcIsAuthenticated"
    class="about"
  >
    <Table></Table>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
import jsonMarkup from 'json-markup'
import SignedInUser from '@/components/SignedInUser'

import Table from '@/components/Table'

export default {
  name: 'Protected',
  components: { SignedInUser, Table },
  computed: {
    ...mapGetters('oidcStore', [
      'oidcIsAuthenticated',
      'oidcUser'
    ]),
    userDisplay: function () {
      return jsonMarkup(this.oidcUser)
    }
  }
}
</script>

<style>
.json-markup {
  color: transparent;
}
.json-markup span {
  color: black;
  float: left;
}
.json-markup .json-markup-key {
  clear: left;
}
</style>
