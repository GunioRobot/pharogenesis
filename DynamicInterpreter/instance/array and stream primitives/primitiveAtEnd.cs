primitiveAtEnd
	| stream array index limit arrayClass size |
	stream _ self popStack.
	successFlag _ ((self isPointers: stream)
			and: [(self lengthOf: stream) >= (StreamReadLimitIndex+1)]).
 	successFlag ifTrue: [
		array _ self fetchPointer: StreamArrayIndex ofObject: stream.
		index _ self fetchInteger: StreamIndexIndex ofObject: stream.
		limit _ self fetchInteger: StreamReadLimitIndex ofObject: stream.
		arrayClass _ self fetchClassOf: array.
		self success: (self okStreamArrayClass: arrayClass).
		size _ self stSizeOf: array].
 	successFlag
		ifTrue: [self pushBool: (index >= limit) | (index >= size)]
		ifFalse: [self unPop: 1].