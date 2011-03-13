sendMail: aCollectionOfMessages
	"Send <aCollectionOfMessages> to the SMTP server."

	| sender n message recipients socket |

	self requiredCategory: '.sent.'.

	self preSendAuthentication.

	sender _ (MailAddressParser addressesIn: self class userName) first.

	[socket _ SMTPSocket usingServer: Celeste smtpServer]
		ifError: [ :a :b | self error: 'error opening connection to mail server'].

	('sending ', aCollectionOfMessages size printString, ' messages...')
		displayProgressAt: Sensor mousePoint
		from: 1
		to: aCollectionOfMessages size
		during: [:progressBar |
			n _ 0.
			aCollectionOfMessages do: [:id |
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

