primitiveSignal

	| sema |
	sema _ self stackTop.  "rcvr"
	self successIfClassOf: sema is: (self splObj: ClassSemaphore).
	successFlag ifTrue: [ self synchronousSignal: sema ].