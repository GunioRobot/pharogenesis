primitiveSignal
"synchromously signal the semaphore. This may change the active process as a result"
	| sema |
	sema _ self stackTop.  "rcvr"
	self assertClassOf: sema is: (self splObj: ClassSemaphore).
	successFlag ifTrue: [ self synchronousSignal: sema ].