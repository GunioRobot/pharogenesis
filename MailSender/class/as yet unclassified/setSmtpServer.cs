setSmtpServer
	"Set the SMTP server used to send outgoing messages via"
	SmtpServer ifNil: [SmtpServer _ ''].
	SmtpServer _ FillInTheBlank
		request: 'What is your mail server for outgoing mail?'
		initialAnswer: SmtpServer.
