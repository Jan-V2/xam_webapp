import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import wiki from "@/components/wiki_querier"

Vue.use(Router);

export default new Router({
    routes: [
        {
            path: '/',
            name: 'HelloWorld',
            component: HelloWorld
        },
        {
            path: '/wiki',
            name: 'bla',
            component: wiki
        },



    ]
})
