sortByDate
	"Sort the message-list by date of time-stamp"

	| assocs aCompiledMethod aDate inOrder |
	assocs _ messageList collect:
		[:aRef |
			aDate _ aRef methodSymbol == #Comment
				ifTrue:
					[aRef actualClass organization dateCommentLastSubmitted]
				ifFalse:
					[aCompiledMethod _ aRef actualClass compiledMethodAt: aRef methodSymbol ifAbsent: [nil].
					aCompiledMethod ifNotNil: [aCompiledMethod dateMethodLastSubmitted]].
			aRef -> (aDate ifNil: [Date fromString: '01/01/1996'])].  "The dawn of Squeak history"
	inOrder _ assocs asSortedCollection:
		[:a :b | a value < b value].

	messageList _ inOrder asArray collect: [:assoc | assoc key].
	self changed: #messageList