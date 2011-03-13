setNewPassword: aString
	"Set a new parallell password the user can use to get in
	if the old password is forgotten. We don't delete the old
	password since the request for this new password is made
	anonymously. Note that the password is stored as a secured
	hash large integer."

	newPassword := SecureHashAlgorithm new hashMessage: aString