exportCategoryUnix
	"Store the filtered message list of the current category into a Eudora/Unix database"
	| destFileName destFile messageIds count |
	mailDB ifNil: [ ^self ].

	destFileName _ FillInTheBlank
		request: 'Destination mail file?'
		initialAnswer: ''.
	(destFileName isEmpty) ifTrue: [^self].
	destFile _ FileStream fileNamed: destFileName.
	destFile ifNil: [ ^self error: 'could not open file' ].
	destFile setToEnd.

	messageIds _ self filteredMessages.

	('exporting ', messageIds size printString, ' messages')
		displayProgressAt: Sensor mousePoint
		from: 0
		to: messageIds size
		during: [ :bar |
			count _ 0.
			messageIds do: [ :messageId |
				destFile nextPutAll: Celeste eudoraSeparator.
				(mailDB getMessage: messageId) text linesDo: [ :line |
					(line beginsWith: 'From ') ifTrue: [ destFile nextPut: $> ].
					destFile nextPutAll: line.
					destFile cr ].
				count _ count + 1.
				bar value: count. ].
		].

	destFile close.
