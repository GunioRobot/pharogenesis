primitiveFileOpen

	| writeFlag namePointer filePointer file nameIndex nameSize |
	self var: 'file' declareC: 'SQFile *file'.
	writeFlag _ self booleanValueOf: (self stackTop).
	namePointer _ self stackValue: 1.
	self success: (self isBytes: namePointer).
	successFlag ifTrue: [
		filePointer _ self instantiateClass: (self splObj: ClassByteArray)
						   indexableSize: self fileRecordSize.
		file _ self fileValueOf: filePointer.
		nameIndex _ namePointer + BaseHeaderSize.
		nameSize _ self lengthOf: namePointer.
	].
	successFlag ifTrue: [
		self cCode: 'sqFileOpen(file, nameIndex, nameSize, writeFlag)'.
	].
	successFlag ifTrue: [
		self pop: 3.  "rcvr, name, writeFlag"
		self push: filePointer.
	].