isolationSet: setOrNil

	setOrNil == self
		ifTrue: [isolationSet _ nil]  "Means this IS the isolation set"
		ifFalse: [isolationSet _ setOrNil]