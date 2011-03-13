otherPinFrom: aPin
	(pins at: 1) = aPin
		ifTrue: [^ pins at: 2]
		ifFalse: [^ pins at: 1]