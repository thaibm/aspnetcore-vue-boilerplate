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
		url: `/api/services/app/Session/GetCurrentLoginInformations`,
		data: param
	})
}

const APP_SERVICES = {
	login: login,
	getCurrentLoginInformations: getCurrentLoginInformations
}

Object.freeze(APP_SERVICES)

export default APP_SERVICES
