sendQueuedMail
	"Post queued messages to the SMTP server."
	| outgoing |
	mailDB ifNil: [ ^self ].
	outgoing _ mailDB messagesIn: '.tosend.'.
	outgoing isEmpty
		ifTrue: [^ self inform: 'no mail to be sent'].
	outgoing _ outgoing asArray.  "make sure we don't use the internal data structure of the mail DB"
	^ self sendMail: outgoing