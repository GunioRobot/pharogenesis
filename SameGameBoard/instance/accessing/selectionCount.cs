selectionCount

	^ selection isNil
		ifTrue: [0]
		ifFalse: [selection size]