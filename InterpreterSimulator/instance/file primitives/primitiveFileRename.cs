primitiveFileRename

	| oldNamePointer newNamePointer f |
	oldNamePointer _ self stackTop.
	newNamePointer _ self stackValue: 1.
	self success: (self isBytes: oldNamePointer).
	self success: (self isBytes: newNamePointer).
	self success: (StandardFileStream isAFileNamed: (self stringOf: oldNamePointer)).
	self success: (StandardFileStream isAFileNamed: (self stringOf: newNamePointer)) not.
	successFlag ifTrue: [
		f _ FileStream oldFileNamed: (self stringOf: oldNamePointer).
		f rename: (self stringOf: newNamePointer).
		f close.
	].
	successFlag ifTrue: [
		self pop: 2.  "oldName, newName; leave rcvr on stack"
	].