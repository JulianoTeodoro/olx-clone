
import { createRouter, createWebHistory } from 'vue-router'
import Home from '../pages/Home/HomeVue.vue'
import About from '../pages/About/AboutVue.vue'
import NotFound from '../pages/404/NotFound.vue'
import Login from '../pages/Login/SignIn.vue'


const routes = ([
    {
        path: '',
        component: () => import('@/layouts/DefaultTemplate.vue'),
        children: [
            {
                path: '',
                name: 'HomeVue',
                component: Home
            },
            {
                path: 'sobre',
                name: 'SobreVue',
                component: About
            },
            {
                path: 'signin',
                name: 'LoginVue',
                component: Login
            },
            {
                path: '/:pathMatch(.*)',
                component: NotFound
            },
        ]
    },
])

export default createRouter({
    history: createWebHistory(),
    linkExactActiveClass: 'active',
    routes
})

