PROTOsendQueuedMail
	"Post queued messages to the SMTP server."

	| outgoing |

	outgoing _ mailDB messagesIn: '.tosend.'.
	outgoing isEmpty ifTrue: [^ self inform: 'no mail to be sent'].
	self sendMail: outgoing.