primitiveTimesTwoPower
	"Use Smalltalk's native function (tho could just fail)"

	| rcvr arg |
	arg _ self popInteger.
	rcvr _ self popFloat.
	successFlag
		ifTrue: [ self pushFloat: (rcvr timesTwoPower: arg) ]
		ifFalse: [ self unPop: 2 ].