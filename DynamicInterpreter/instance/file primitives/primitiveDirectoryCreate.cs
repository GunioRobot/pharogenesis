primitiveDirectoryCreate

	| dirName dirNameIndex dirNameSize |
	dirName _ self stackTop.
	self success: (self isBytes: dirName).
	successFlag ifTrue: [
		dirNameIndex _ dirName + BaseHeaderSize.
		dirNameSize _ self lengthOf: dirName.
	].
	successFlag ifTrue: [
		self success:
			(self cCode: 'dir_Create((char *) dirNameIndex, dirNameSize)').
	].
	successFlag ifTrue: [
		self pop: 1.  "pop dirName; leave rcvr on stack"
	].