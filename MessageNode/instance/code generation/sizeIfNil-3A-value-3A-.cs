sizeIfNil: encoder value: forValue

	| theNode theSize theSelector |
	equalNode := encoder encodeSelector: #==.
	sizes := Array new: 1.
	theNode := arguments first.
	theSelector := #ifNotNil:.
	forValue
		ifTrue:
			[sizes at: 1 put: (theSize := (1 "pop" + (theNode sizeForEvaluatedValue: encoder))).
			 ^(receiver sizeForValue: encoder) +
				2 "Dup. LdNil" +
				(equalNode size: encoder args: 1 super: false) +
				(self 
					sizeBranchOn: (selector key == theSelector) 
					dist: theSize) +
				theSize]
		ifFalse:
			[sizes at: 1 put: (theSize := (theNode sizeForEvaluatedEffect: encoder)).
			 ^(receiver sizeForValue: encoder) +
				1 "LdNil" +
				(equalNode size: encoder args: 1 super: false) +
				(self 
					sizeBranchOn: (selector key == theSelector) 
					dist: theSize) +
				theSize]

