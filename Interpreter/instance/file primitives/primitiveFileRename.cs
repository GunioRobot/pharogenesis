primitiveFileRename

	| oldNamePointer newNamePointer oldNameIndex oldNameSize newNameIndex newNameSize |
	newNamePointer _ self stackTop.
	oldNamePointer _ self stackValue: 1.
	self success: (self isBytes: newNamePointer).
	self success: (self isBytes: oldNamePointer).
	successFlag ifTrue: [
		newNameIndex _ newNamePointer + BaseHeaderSize.
		newNameSize _ self lengthOf: newNamePointer.
		oldNameIndex _ oldNamePointer + BaseHeaderSize.
		oldNameSize _ self lengthOf: oldNamePointer.
	].
	successFlag ifTrue: [
		self sqFileRenameOld: oldNameIndex Size: oldNameSize New: newNameIndex Size: newNameSize.
	].
	successFlag ifTrue: [
		self pop: 2.  "pop new and old names, leave rcvr on stack"
	].