popPassword
	"Answer the password to use when retrieving mail via POP3. The password disappears when you close the Celeste window."

	^ popPassword ifNil: [self setPopPassword]