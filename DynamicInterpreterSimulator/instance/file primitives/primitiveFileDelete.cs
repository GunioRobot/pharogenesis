primitiveFileDelete

	| namePointer |
	namePointer _ self stackTop.
	self success: (self isBytes: namePointer).
	self success: (FileDirectory includesKey: (self stringOf: namePointer)).
	successFlag ifTrue: [
		FileDirectory removeKey: (self stringOf: namePointer) ifAbsent: [].
	].
	successFlag ifTrue: [
		self pop: 1.  "fileName; leave rcvr on stack"
	].