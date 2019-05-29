<template>
  <div
    v-if="oidcIsAuthenticated"
    class="about"
  >
    <Table :columns="columns" :table-data="tableData"></Table>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
import { getTransactionHistory } from '@/services/banking.api'
import columConfig from './column-config'
import Table from '@/components/Table'

export default {
  name: 'Protected',
  components: { Table },
  data () {
    return {
      columns: columConfig,
      tableData: []
    }
  },
  computed: {
    ...mapGetters('oidcStore', [
      'oidcIsAuthenticated',
      'oidcUser'
    ]),
    ...mapGetters('user', [
      'account'
    ])
  },
  mounted () {
    const vm = this
    const userId = vm.$store.getters['oidcStore/oidcUser'].sub
    vm.$store.dispatch('initBankingAccount', { accountid: userId })
      .then((account) => getTransactionHistory(account.id)
        .then((data) => {
          vm.$data.tableData = data
        })
      )
      .catch(err => console.log(err))
  },
  destroyed () {
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
