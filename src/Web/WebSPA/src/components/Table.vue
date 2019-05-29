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
  props: ['columns', 'tableData']
}
</script>
