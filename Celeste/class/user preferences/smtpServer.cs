smtpServer
	"Answer the server for sending email"

	(SmtpServer isNil or: [SmtpServer isEmpty])
		ifTrue: [self setSmtpServer].
	SmtpServer isEmpty ifTrue: [
		self error: 'no SMTP server specified' ].

	^SmtpServer