

<template>
    <div>
        <button @click="test_sqlite()">test sqlite</button>
        <li v-for="item in _store.sqlite_test">{{item}}</li>
    </div>
</template>

<script>
    export default {
        name: 'tester',
        data: function() {
            return {
            }
        },
        computed:{
            _store: function () {
                return store.test;
            }
        },
        methods: {
            test_sqlite: function () {

            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
