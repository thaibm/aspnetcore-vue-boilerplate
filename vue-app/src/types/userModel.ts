export interface UserAccount {
	usernameOrEmailAddress: string,
	password: string
}

export interface UserDetails {
	emailAddress: string,
	id: 1,
	name: string,
	surname: string,
	userName: string,
}

export enum UserRole {
	Admin,
	User
}

export interface RegisterAccount {
	name: string,
	surname: string,
	emailAddress: string,
	userName: string,
	password: string
}
