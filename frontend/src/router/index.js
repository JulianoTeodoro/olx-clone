import VueRouter from "vue-router";
import Vue from 'vue'

import Home from '../pages/Home/HomeVue.vue'
import About from '../pages/About/AboutVue.vue'
import NotFound from '../pages/404/ErrorS404.vue'

Vue.use(VueRouter)

const routes = ([
    {
        path: '',
        component: () => import('@/layouts/DefaultTemplate.vue'),
        children: [
            {
                path: '/',
                component: Home
            },
            {
                path: '/sobre',
                component: About
            },
            {
                path: '*',
                component: NotFound
            }
        ]
    },
])

const router = new VueRouter({
    mode: 'history',
    linkExactActiveClass: 'active',
    routes
})

export default router