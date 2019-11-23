import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/views/Home.vue'
import store from '@/store'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home,
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import('@/views/About.vue'),
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/login',
    component: () => import('@/views/Login.vue')
  },
  {
    path: '/resources',
    name: 'resources',
    component: () => import('@/components/resources/Resources.vue'),
    meta: {
      requiresAuth: true
    }
  },
  {
    path: '/register',
    component: () => import('@/views/Register.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (store.getters['AppModule/isAuthenticated']) {
      next()
      return
    }
    next('/login')
  } else {
    next()
  }
})

export default router
