popPassword
	"Answer the password to use when retrieving mail via POP3. The password is stored in an instance variable, which disappears when you close the Celeste window."

	userPassword ifNotNil: [^ userPassword].
	userPassword _ FillInTheBlank requestPassword: 'POP password'.
	^ userPassword
