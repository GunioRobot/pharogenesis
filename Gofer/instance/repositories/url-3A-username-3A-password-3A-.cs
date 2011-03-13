url: aString username: aUsernameString password: aPasswordString
	"Set the repository URL aString as the location for the following package additions."

	self repository: (MCHttpRepository
		location: aString
		user: aUsernameString
		password: aPasswordString)