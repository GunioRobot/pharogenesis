positionOfSubCollection: subCollection ifAbsent: exceptionBlock
	"Return a position such that that element at the new position equals the first element of sub, and the next elements equal the rest of the elements of sub. Begin the search at the current position.
	If no such match is found, answer the result of evaluating argument, exceptionBlock."

	| pattern startPosition currentPosition |
	pattern _ ReadStream on: subCollection.
	startPosition := self position.
	[pattern atEnd] whileFalse: 
		[self atEnd ifTrue: [^exceptionBlock value].
		self next = pattern next
			ifFalse: [pattern reset]].
	currentPosition := self position.
	self position: startPosition.
	^pattern atEnd
		ifTrue: [currentPosition + 1 - subCollection size]
		ifFalse: [exceptionBlock value]