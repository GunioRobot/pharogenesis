primitivePointY
	| rcvr | 
	self inline: false.
	rcvr _ self popStack.
	self assertClassOf: rcvr is: (self splObj: ClassPoint).
	successFlag
		ifTrue: [self push: (self fetchPointer: YIndex ofObject: rcvr)]
		ifFalse: [self unPop: 1]