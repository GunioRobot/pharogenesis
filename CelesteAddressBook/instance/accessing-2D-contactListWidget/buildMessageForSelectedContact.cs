buildMessageForSelectedContact
	"selectedContactItem must be not nil or an error will arise!"
	| msg |
	msg := MailMessage empty.
	msg setField: 'subject' toString: ''.
	msg setField: 'to' toString: (self selectedContactItem asString).
	msg setField: 'from' toString: (celeste account userName asString).
	^msg