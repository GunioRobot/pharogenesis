nextOrNil
	hasBeenRead ifTrue:[ ^nil ].
	hasBeenRead _ true.
	^inputMessage