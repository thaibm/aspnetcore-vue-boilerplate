import { Module } from 'vuex'
import { GetterTree } from 'vuex'
import { ActionTree } from 'vuex'
import { MutationTree } from 'vuex'
import { RootState } from '@/store/index'
import axios from 'axios'

interface AppState {
    status: string,
    token: string,
    user: any
}
const state: AppState = {
    status: '',
    token: localStorage.getItem('token') || '',
    user: {}
}

const getters: GetterTree<AppState, RootState> = {
    isAuthenticated(state): boolean {
        return !!state.token
    },
    authStatus: state => state.status
}

const mutations: MutationTree<AppState> = {
    AUTH_REQUEST(state) {
        state.status = 'loading'
    },
    AUTH_SUCCESS(state, data: any) {
        state.status = 'success'
        state.token = data.token
        state.user = data.user
    },
    AUTH_ERROR(state) {
        state.status = 'error'
    },
    LOGOUT(state) {
        state.status = ''
        state.token = ''
    }
}

const actions: ActionTree<AppState, RootState> = {
    login({ commit }, user) {
        return new Promise((resolve, reject) => {
            commit('AUTH_REQUEST')
            axios({ url: 'http://localhost:21021/api/TokenAuth/Authenticate', data: user, method: 'POST' })
                .then(resp => {
                    const token = resp.data.result.accessToken
                    const user = resp.data.result.userId
                    
                    localStorage.setItem('token', token)
                    // Add the following line:
                    axios.defaults.headers.common['Authorization'] = token
                    commit('AUTH_SUCCESS', { token, user })
                    resolve(resp)
                })
                .catch(err => {
                    commit('AUTH_ERROR')
                    localStorage.removeItem('token')
                    reject(err)
                })
        })
    },
    logout({ commit }): Promise<any> {
        return new Promise((resolve, reject) => {
            commit('LOGOUT')
            localStorage.removeItem('token')
            delete axios.defaults.headers.common['Authorization']
            resolve()
        })
    }
}

export const AppModule: Module<AppState, RootState> = {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
}
