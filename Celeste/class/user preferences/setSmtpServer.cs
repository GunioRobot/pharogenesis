setSmtpServer
	"Set the SMTP server used to send outgoing messages via"

	(SmtpServer isNil) ifTrue: [
		PopServer isNil
			ifTrue: [ SmtpServer _ '' ]
			ifFalse: [ SmtpServer _ PopServer ] ].

	SmtpServer _ FillInTheBlank
		request: 'What is your mail server for outgoing mail?'
		initialAnswer: SmtpServer.
