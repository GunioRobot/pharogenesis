primitiveFileDelete

	| namePointer nameIndex nameSize |
	namePointer _ self stackTop.
	self success: (self isBytes: namePointer).
	successFlag ifTrue: [
		nameIndex _ namePointer + BaseHeaderSize.
		nameSize _ self lengthOf: namePointer.
	].
	successFlag ifTrue: [
		self sqFileDeleteName: nameIndex Size: nameSize.
	].
	successFlag ifTrue: [ self pop: 1. "pop name, leave rcvr on stack" ].
