sendMail: aCollectionOfMessages
	"Send <aCollectionOfMessages> to the SMTP server."

	| sender n message client |

	self requiredCategory: '.sent.'.

	client _ SMTPClient new.
	self account fillInSmtpInfo: client.
	client ensureConnection.

	sender _ self account sender.

	('sending ', aCollectionOfMessages size printString, ' messages...')
		displayProgressAt: Sensor mousePoint
		from: 1
		to: aCollectionOfMessages size
		during: [:progressBar |
			n _ 0.
			aCollectionOfMessages do: [:id |
				progressBar value: (n _ n + 1).
				message _ mailDB getMessage: id.

				client 
					mailFrom: sender
					to: message recipients 
					text: message text.	"send this one message on the stream"

				mailDB remove: id fromCategory: '.tosend.'.
				mailDB file: id inCategory: '.sent.'
		].
	].

	client quit; close.
	mailDB saveDB.

	(self category = '.tosend.') |  (self category = '.sent.') ifTrue: [self updateTOC].

	self changed: #outBoxStatus.