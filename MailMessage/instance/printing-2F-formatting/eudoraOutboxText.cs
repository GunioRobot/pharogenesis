eudoraOutboxText
	"Return this message formatted for inclusion in a Eudora outbox."

	| old new |
	old _ ReadStream on: text.
	new _ WriteStream on: (String new: text size).
	MailMessage new fieldsFrom: old do: [ :fName :fValue | "skip header fields" ].
	new nextPutAll: 'To: ';		nextPutAll: to; cr.
	new nextPutAll: 'From: ';	nextPutAll: from; cr.
	new nextPutAll: 'Subject: ';	nextPutAll: subject; cr.
	new nextPutAll: 'Cc: ';		nextPutAll: cc; cr.
	new nextPutAll: 'Bcc: '; cr.
	new nextPutAll: 'X-attachments: '; cr.
	new cr.
	new nextPutAll: old upToEnd.
	^new contents