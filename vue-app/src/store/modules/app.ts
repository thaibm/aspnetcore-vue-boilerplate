import APP_SERVICES from '@/services/app'
import { RootState } from '@/store'
import { UserDetails } from '@/types/userModel'
import { ActionTree, GetterTree, Module, MutationTree } from 'vuex'

interface AppState {
	authStatus: string
	authToken: string
	userDetails: any
}
const state: AppState = {
	authStatus: '',
	authToken: localStorage.getItem('AuthToken') || '',
	userDetails: {}
}

const getters: GetterTree<AppState, RootState> = {
	isAuthenticated(state): boolean {
		return !!state.authToken
	},
    authStatus: state => state.authStatus,
    userDetails: state => state.userDetails
}

const mutations: MutationTree<AppState> = {
	AUTH_REQUEST(state) {
		state.authStatus = 'loading'
	},
	AUTH_SUCCESS(state, data: any) {
		state.authStatus = 'success'
		state.authToken = data.token
	},
	AUTH_ERROR(state) {
		state.authStatus = 'error'
	},
	LOGOUT(state) {
		state.authStatus = ''
		state.authToken = ''
	},
	SET_USER_DETAILS(state, userDetails: UserDetails) {
		state.userDetails = userDetails
	}
}

const actions: ActionTree<AppState, RootState> = {
	async login({ commit }, userAccount): Promise<any> {
		try {
			commit('AUTH_REQUEST')
			const response = await APP_SERVICES.login(userAccount)
			const token = response.result.accessToken
			const userId = response.result.userId
			localStorage.setItem('AuthToken', token)
			localStorage.setItem('UserId', userId)
			commit('AUTH_SUCCESS', { token })

			return response
		} catch (error) {
			commit('AUTH_ERROR')
			localStorage.removeItem('AuthToken')
			console.error(error)
		}
	},
	logout({ commit }) {
		commit('LOGOUT')
		localStorage.removeItem('AuthToken')
    },
    async getCurrentLoginInformations({ commit }): Promise<any> {
		const response = await APP_SERVICES.getCurrentLoginInformations()
		const userDetails = response.result.user
		commit('SET_USER_DETAILS', userDetails)
		return response
	}
}

export const AppModule: Module<AppState, RootState> = {
	namespaced: true,
	state,
	getters,
	actions,
	mutations
}
