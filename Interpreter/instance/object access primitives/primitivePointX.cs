primitivePointX

	| rcvr | 
	successFlag _ true.
	rcvr _ self popStack.
	self assertClassOf: rcvr is: (self splObj: ClassPoint).
	successFlag
		ifTrue: [self push: (self fetchPointer: XIndex ofObject: rcvr)]
		ifFalse: [self unPop: 1.  self failSpecialPrim: 0  "will fail"]