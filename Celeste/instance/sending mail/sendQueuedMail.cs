sendQueuedMail
	"Post queued messages to the SMTP server."

	| outgoing sender n message recipients socket |
	outgoing _ mailDB messagesIn: '.tosend.'.
	outgoing isEmpty ifTrue: [^ self inform: 'no mail to be sent'].

	self requiredCategory: '.sent.'.

	self preSendAuthentication.

	sender _ (MailAddressParser addressesIn: self class userName) first.

	[socket _ SMTPSocket usingServer: Celeste smtpServer]
		ifError: [ :a :b | self error: 'error opening connection to mail server'].

	('sending ', outgoing size printString, ' messages...')
		displayProgressAt: Sensor mousePoint
		from: 1
		to: outgoing size
		during: [:progressBar |
			n _ 0.
			outgoing do: [:id |
				progressBar value: (n _ n + 1).
				message _ mailDB getMessage: id.

				recipients _ Set new.
				recipients addAll: (MailAddressParser addressesIn: message to).
				recipients addAll: (MailAddressParser addressesIn: message cc).

				[socket 
					mailFrom: sender
					to: recipients 
					text: message text.	"send this one message on the stream"

				mailDB remove: id fromCategory: '.tosend.'.
				mailDB file: id inCategory: '.sent.'
				] ifError: [ :a :b | self error: 'error posting mail']
		]].

	socket quit; close.
	mailDB saveDB.

	(self category = '.tosend.') |  (self category = '.sent.') ifTrue: [self updateTOC].

