match: subCollection
	"Set the access position of the receiver to be past the next occurrence of the subCollection. Answer whether subCollection is found.  No wildcards, and case does matter."

	| pattern startMatch |
	pattern _ ReadStream on: subCollection.
	startMatch _ nil.
	[pattern atEnd] whileFalse: 
		[self atEnd ifTrue: [^false].
		(self next) = (pattern next) 
			ifTrue: [pattern position = 1 ifTrue: [startMatch _ self position]]
			ifFalse: [pattern position: 0.
					startMatch ifNotNil: [
						self position: startMatch + 1.
						startMatch _ nil]]].

	^self atEnd

