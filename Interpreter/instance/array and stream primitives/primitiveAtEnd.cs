primitiveAtEnd
	| stream index limit |
	stream _ self popStack.
	successFlag _ ((self isPointers: stream)
			and: [(self lengthOf: stream) >= (StreamReadLimitIndex+1)]).
 	successFlag ifTrue: [
		index _ self fetchInteger: StreamIndexIndex ofObject: stream.
		limit _ self fetchInteger: StreamReadLimitIndex ofObject: stream].
 	successFlag
		ifTrue: [self pushBool: (index >= limit)]
		ifFalse: [self unPop: 1].