setUserName
	self userName: (FillInTheBlank
		request: 'What is your email address?\(This is the address other people will reply to you)' withCRs
		initialAnswer: (userName ifNil: ['']) isoToSqueak).
	^ userName