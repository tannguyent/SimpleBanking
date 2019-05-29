<template>
  <el-table
    :data="tableData"
    stripe
    style="width: 100%">
    <el-table-column v-for="column in columns"
                         :key="column.label"
                         :prop="column.prop"
                         :label="column.label"
                         :formatter="column.formatter"
                         :min-width="column.minWidth">
        </el-table-column>
  </el-table>
</template>

<script>
export default {
  data () {
    return {
      columns: [
        {
          prop: 'date',
          label: 'Date'
        },
        {
          prop: 'name',
          label: 'Name'
        },
        {
          prop: 'address',
          label: 'Address'
        }
      ],
      tableData: [{
        date: '2016-05-03',
        name: 'Tom',
        address: 'No. 189, Grove St, Los Angeles'
      }, {
        date: '2016-05-02',
        name: 'Tom',
        address: 'No. 189, Grove St, Los Angeles'
      }, {
        date: '2016-05-04',
        name: 'Tom',
        address: 'No. 189, Grove St, Los Angeles'
      }, {
        date: '2016-05-01',
        name: 'Tom',
        address: 'No. 189, Grove St, Los Angeles'
      }]
    }
  }
}
</script>
