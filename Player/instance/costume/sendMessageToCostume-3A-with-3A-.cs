sendMessageToCostume: aSelector with: arg
	| aCostume |
	(aCostume _ self costumeRespondingTo: aSelector) ifNotNil:
		[^ aCostume perform: aSelector with: arg].
	^ nil