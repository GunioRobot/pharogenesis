sizeIfNil: encoder value: forValue

	| theNode theSize theSelector |
	equalNode _ encoder encodeSelector: #==.
	sizes _ Array new: 1.
	theNode _ arguments first.
	theSelector _ #ifNotNil:.
	forValue
		ifTrue:
			[sizes at: 1 put: (theSize _ (1 "pop" + (theNode sizeForEvaluatedValue: encoder))).
			 ^(receiver sizeForValue: encoder) +
				2 "Dup. LdNil" +
				(equalNode size: encoder args: 1 super: false) +
				(self 
					sizeBranchOn: (selector key == theSelector) 
					dist: theSize) +
				theSize]
		ifFalse:
			[sizes at: 1 put: (theSize _ (theNode sizeForEvaluatedEffect: encoder)).
			 ^(receiver sizeForValue: encoder) +
				1 "LdNil" +
				(equalNode size: encoder args: 1 super: false) +
				(self 
					sizeBranchOn: (selector key == theSelector) 
					dist: theSize) +
				theSize]

