search
	"Search the text of all messages in the present category"

	| destCat matchString msgText |
	mailDB ifNil: [ ^self ].
	destCat _ FillInTheBlank
		request: 'In what category should the search results be filed?'
		initialAnswer: '.search results.'.
	(destCat isEmpty) ifTrue: [^self].
	matchString _ FillInTheBlank
		request: 'String sought in message text?'
		initialAnswer: ''.
	(matchString isEmpty) ifTrue: [^self].

	self requiredCategory: destCat.

	(self filteredMessages) do:
		[: msgID |
		 msgText _ mailDB getText: msgID.
		 ((msgText findString: matchString startingAt: 1) > 0) ifTrue:
			[mailDB file: msgID inCategory: destCat]].

	self setCategory: destCat.

