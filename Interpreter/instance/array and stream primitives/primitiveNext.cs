primitiveNext

	| stream array index limit arrayClass stringy result |
	stream _ self popStack.
	successFlag _
		((self isPointers: stream) and:
		 [(self lengthOf: stream) >= (StreamReadLimitIndex + 1)]).
 	successFlag ifTrue: [
		array _ self fetchPointer: StreamArrayIndex ofObject: stream.
		index _ self fetchInteger: StreamIndexIndex ofObject: stream.
		limit _ self fetchInteger: StreamReadLimitIndex ofObject: stream.
		arrayClass _ self fetchClassOf: array.
		stringy _ arrayClass = (self splObj: ClassString).
		stringy ifFalse: [
			self success: (self okStreamArrayClass: arrayClass)].
		self success: index < limit].
	successFlag ifTrue: [
		index _ index + 1.
		self pushRemappableOop: stream.
		result _ self stObject: array at: index.  "may cause GC!"
		stream _ self popRemappableOop].
	successFlag ifTrue: [
		self storeInteger: StreamIndexIndex
			ofObject: stream
			withValue: index].
	successFlag ifTrue: [
		stringy
			ifTrue: [self push: (self characterForAscii: result)]
			ifFalse: [self push: result].
	] ifFalse: [
		self unPop: 1].
