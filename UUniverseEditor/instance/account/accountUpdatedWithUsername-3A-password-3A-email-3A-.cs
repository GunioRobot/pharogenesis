accountUpdatedWithUsername: newUsername  password:  newPassword  email: newEmail
	self acceptFields.
	username _ newUsername.
	password _ newPassword.
	email _ newEmail.
	
	self changed: #username.
	self changed: #password.
	self changed: #email.
	
	self closeAccountEditor