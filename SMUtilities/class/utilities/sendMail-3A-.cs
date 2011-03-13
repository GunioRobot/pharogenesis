sendMail: aString
	"Send the given mail message, but check for modern mail senders."

	| server |

	Smalltalk at: #MailSender ifPresent: [ :mailSender |
		^mailSender sendMessage: ((Smalltalk at: #MailMessage) from: aString).
	].

	Smalltalk at: #MailComposition ifPresent: [ :mailComposition |
		^mailComposition new
			messageText:  aString;
			open
	].
	
	Smalltalk at: #Celeste ifPresent: [ :celeste |
		celeste isSmtpServerSet ifTrue: [
			Smalltalk at: #CelesteComposition ifPresent: [ :celesteComposition |
				^celesteComposition
					openForCeleste: celeste current 
					initialText: aString
			]
		]
	].

	Smalltalk at: #AdHocComposition ifPresent: [ :adHocComposition |
		server := UIManager default request: 'What is your mail server for outgoing mail?'.
		^adHocComposition 
			openForCeleste: server
			initialText: aString
	].

	^self inform: 'Sorry, no known way to send the message'.
	 	