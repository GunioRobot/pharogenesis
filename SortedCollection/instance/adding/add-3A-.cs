add: newObject

	| nextIndex |
	self isEmpty ifTrue: [^self addLast: newObject].
	nextIndex _ self indexForInserting: newObject.
	self insert: newObject before: nextIndex.
	^newObject