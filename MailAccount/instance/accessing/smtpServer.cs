smtpServer
	smtpServer isEmptyOrNil ifTrue:[
		self error: 'no SMTP server specified'.
	].
	^ smtpServer.