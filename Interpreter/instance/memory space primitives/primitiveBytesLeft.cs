primitiveBytesLeft
	"Reports bytes available at this moment. For more meaningful 
	results, calls to this primitive should be preceeded by a full 
	or incremental garbage collection."
	| aBool |
	self methodArgumentCount = 0
		ifTrue: ["old behavior - just return the size of the free block"
			self pop: 1.
			^ self pushInteger: (self sizeOfFree: freeBlock)].
	self methodArgumentCount = 1
		ifTrue: ["new behaviour -including or excluding swap space depending on aBool"
			aBool _ self booleanValueOf: self stackTop.
			successFlag ifFalse: [^ nil].
			self pop: 2.
			^ self pushInteger: (self bytesLeft: aBool)].
	^ self primitiveFail