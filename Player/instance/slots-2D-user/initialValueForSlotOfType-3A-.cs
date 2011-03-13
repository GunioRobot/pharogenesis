initialValueForSlotOfType: aType
	"Answer the default initial value to ascribe to a slot of the given type"

	aType == #number ifTrue: [^ (1 to: 9) atRandom].
	aType == #boolean ifTrue: [^ true].
	aType == #player ifTrue: [^ self costume presenter standardPlayer].
	aType == #color ifTrue: [^ Color random].
	aType == #string ifTrue: [^ 'abc'].
	aType == #sound ifTrue: [^ 'croak'].
	aType == #point ifTrue: [^ 20 @ 30].
	aType == #buttonPhase ifTrue: [^ #buttonUp].
	^ nil