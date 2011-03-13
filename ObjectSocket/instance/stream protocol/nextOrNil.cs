nextOrNil
	inObjects isEmpty
		ifTrue: [ ^nil ]
		ifFalse: [ ^inObjects removeFirst ]