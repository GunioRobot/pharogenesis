exportCategory
	"Store the filtered message list of the current category to another mail database. The user is prompted for the name of the other database."

	| destDBName destDB |
	currentCategory ifNil: [ ^self ].

	destDBName _ FillInTheBlank
		request: 'Destination mail database?'
		initialAnswer: ''.
	(destDBName isEmpty) ifTrue: [^self].
	destDB _ MailDB openOn: destDBName.
	(destDB isNil) ifTrue: [^self].
	destDB mergeMessages: (self filteredMessagesIn: currentCategory) from: mailDB.
	destDB saveDB.
