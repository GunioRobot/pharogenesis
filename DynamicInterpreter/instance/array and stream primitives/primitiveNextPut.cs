primitiveNextPut
	| value stream index limit array arrayClass storeVal |
	value _ self popStack.
	stream _ self popStack.
	successFlag _ ((self isPointers: stream)
			and: [(self lengthOf: stream) >= (StreamWriteLimitIndex+1)]).
 	successFlag ifTrue: [
		array _ self fetchPointer: StreamArrayIndex ofObject: stream.
		index _ self fetchInteger: StreamIndexIndex ofObject: stream.
		limit _ self fetchInteger: StreamWriteLimitIndex ofObject: stream.
		arrayClass _ self fetchClassOf: array.
		self success: (self okStreamArrayClass: arrayClass).
		self success: index < limit].
	successFlag ifTrue:
		[index _ index + 1.
		arrayClass = (self splObj: ClassString)
			ifTrue: [storeVal _ self asciiOfCharacter: value]
			ifFalse: [storeVal _ value].
		self stObject: array at: index put: storeVal].
	successFlag ifTrue:
		[self storeInteger: StreamIndexIndex ofObject: stream
			withValue: index].
	successFlag
		ifTrue: [self push: value]
		ifFalse: [self unPop: 2]