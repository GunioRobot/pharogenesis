primitiveAsFloat
	| arg |
	arg _ self popInteger.
	successFlag
		ifTrue: [ self pushFloat: (self cCode: '((double) arg)') ]
		ifFalse: [ self unPop: 1 ].