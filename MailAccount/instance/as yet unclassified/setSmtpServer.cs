setSmtpServer
	self smtpServer: (FillInTheBlank
		request: 'What is your mail server for outgoing mail?'
		initialAnswer: (smtpServer ifNil: [popServer ifNil: ['']])).
	^ smtpServer