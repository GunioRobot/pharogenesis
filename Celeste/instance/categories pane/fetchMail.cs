fetchMail
	"Append messages from the user's mailbox to this mail database."

	| server password msgCount |
	mailDB ifNil: [ ^self ].
	server _ self account popServer.
	password _ self account popPassword ifNil: [^ self].

	self requiredCategory: 'new'.

	msgCount _ mailDB fetchMailFromPOP: server
		userName: self account popUserName
		password: password
		loginMethod: self class loginMethod
		doFormatting: FormatWhenFetching
		deleteFromServer: DeleteInboxAfterFetching.
	msgCount < 0
		ifTrue: [self inform: 'could not connect to the mail server']
		ifFalse: [
			"self inform: msgCount printString, ' messages fetched'"
			Transcript show: msgCount printString, ' messages fetched'
		].
	msgCount <= 0 ifTrue: [^ self].

	self setCategory: 'new'.

