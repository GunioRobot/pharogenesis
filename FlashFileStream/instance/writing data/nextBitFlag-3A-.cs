nextBitFlag: aBoolean
	^self nextBits: 1 put: (aBoolean ifTrue:[1] ifFalse:[0])