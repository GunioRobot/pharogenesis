initialValueForSlotOfType: aType
	aType == #number ifTrue: [^ (1 to: 9) atRandom].
	aType == #boolean ifTrue: [^ true].
	aType == #player ifTrue: [^ self costume presenter standardPlayer].
	aType == #color ifTrue: [^ Color random].
	aType == #string ifTrue: [^ 'abc'].
	aType == #sound ifTrue: [^ 'croak'].
	aType == #point ifTrue: [^ 20 @ 30].
	^ nil