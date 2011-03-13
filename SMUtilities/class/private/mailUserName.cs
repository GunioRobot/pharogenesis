mailUserName
	"Answer the mail user's name, but deal with some historical mail senders."

	| mailSender |
	mailSender := (Smalltalk at: #MailSender ifAbsent: [ Smalltalk at: #Celeste ifAbsent: []]).
	^mailSender
		ifNil: [ UIManager default request: 'What is your email address?' ]
		ifNotNil: [ mailSender userName ]