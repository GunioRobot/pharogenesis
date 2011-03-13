createAccount
	self acceptFields.

	email _ FillInTheBlankMorph request: 'your email address?'.
	email = '' ifTrue: [ ^self ].

	self sendMessage: (UMAddAccount username: username password: password email: email).
	