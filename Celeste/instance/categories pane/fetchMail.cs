fetchMail
	"Append messages from the user's mailbox to this mail database."

	| server password msgCount |
	server _ self class popServer.
	password _ self popPassword.
	(password isNil or: [password isEmpty]) ifTrue: [^ self].

	self requiredCategory: 'new'.

	msgCount _ mailDB fetchMailFromPOP: server
		userName: self class popUserName
		password: password
		doFormatting: FormatWhenFetching
		deleteFromServer: DeleteInboxAfterFetching.
	msgCount < 0
		ifTrue: [self inform: 'could not connect to the mail server']
		ifFalse: [self inform: msgCount printString, ' messages fetched'].
	msgCount <= 0 ifTrue: [^ self].

	self setCategory: 'new'.

