/*
 ** TODO update domain when deploy app
 */

const URL =
	process.env.NODE_ENV === 'production'
		? 'https://yourdomain/'
		: 'http://localhost:21021/'
export default URL
