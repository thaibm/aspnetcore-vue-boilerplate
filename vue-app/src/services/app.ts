import request from '@/libs/request'
import { UserAccount } from '@/types/userModel'

const login = (userAccount: UserAccount): Promise<any> => {
	const param = {
		usernameOrEmailAddress: userAccount.usernameOrEmailAddress,
		password: userAccount.password
	}
	return request({
		method: 'POST',
		url: `api/TokenAuth/Authenticate`,
		data: param
	})
}

const getCurrentLoginInformations = (): Promise<any> => {
	const param = {}
	return request({
		method: 'GET',
		url: `/api/services/app/Session/GetCurrentLoginInformations/`,
		data: param
	})
}

const register = (data: any): Promise<any> => {
	return request({
		method: 'POST',
		url: `/api/services/app/Account/Register`,
		data
	})
}

const APP_SERVICES = {
	login,
	getCurrentLoginInformations,
	register
}

Object.freeze(APP_SERVICES)

export default APP_SERVICES
