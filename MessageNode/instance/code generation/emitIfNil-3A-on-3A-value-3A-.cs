emitIfNil: stack on: strm value: forValue

	| theNode theSize theSelector |
	theNode _ arguments first.
	theSize _ sizes at: 1.
	theSelector _ #ifNotNil:.
	receiver emitForValue: stack on: strm.
	forValue ifTrue: [strm nextPut: Dup. stack push: 1].
	strm nextPut: LdNil. stack push: 1.
	equalNode emit: stack args: 1 on: strm.
	self 
		emitBranchOn: (selector key == theSelector)
		dist: theSize 
		pop: stack 
		on: strm.
	pc _ strm position.
	forValue 
		ifTrue: 
			[strm nextPut: Pop. stack pop: 1.
			theNode emitForEvaluatedValue: stack on: strm]	
		ifFalse: [theNode emitForEvaluatedEffect: stack on: strm].