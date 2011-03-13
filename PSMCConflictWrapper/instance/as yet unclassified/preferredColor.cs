preferredColor

	^self item isResolved
		ifTrue: [super preferredColor]
		ifFalse: [Color red]