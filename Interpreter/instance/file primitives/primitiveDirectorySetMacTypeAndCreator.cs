primitiveDirectorySetMacTypeAndCreator

	| creatorString typeString fileName creatorStringIndex typeStringIndex fileNameIndex fileNameSize |
	creatorString _ self stackTop.
	typeString _ self stackValue: 1.
	fileName _ self stackValue: 2.
	self success: ((self isBytes: creatorString) and: [(self lengthOf: creatorString) = 4]).
	self success: ((self isBytes: typeString) and: [(self lengthOf: typeString) = 4]).
	self success: (self isBytes: fileName).
	successFlag ifTrue: [
		creatorStringIndex _ creatorString + BaseHeaderSize.
		typeStringIndex _ typeString + BaseHeaderSize.
		fileNameIndex _ fileName + BaseHeaderSize.
		fileNameSize _ self lengthOf: fileName.
	].
	successFlag ifTrue: [
		self success:
			(self cCode: 'dir_SetMacFileTypeAndCreator(
				(char *) fileNameIndex, fileNameSize,
				(char *) typeStringIndex, (char *) creatorStringIndex)').
	].
	successFlag ifTrue: [
		self pop: 3.  "pop filename, type, creator; leave rcvr on stack"
	].