askNamePassword
	"Authorization is required by the host site.  Ask the user for a userName and password.  Encode them and store under this realm.  Return false if the user wants to give up."

	| user password |
	(self confirm: 'Host ', self toText, '
wants a different user and password.  Type them now?' orCancel: [false])
		ifFalse: [^ false].
	"Note: When Scamper is converted to run under MVC, we'll have to pass in topView in order to decide which FillInTheBlank to call."
	user _ FillInTheBlank request: 'User account name?' initialAnswer: '' 
				centerAt: (ActiveHand ifNil:[Sensor]) cursorPoint - (50@0).
	password _ FillInTheBlank requestPassword: 'Password?'.
	Passwords at: realm put: (Authorizer new encode: user password: password).
	^ true