primitiveDirectoryGetMacTypeAndCreator

	| creatorString typeString fileName creatorStringIndex typeStringIndex fileNameIndex fileNameSize |
	self var: 'creatorStringIndex' type: 'char *'.
	self var: 'typeStringIndex' type: 'char *'.
	self var: 'fileNameIndex' type: 'char *'.
	self export: true.
	creatorString _ interpreterProxy stackValue: 0.
	typeString _ interpreterProxy stackValue: 1.
	fileName _ interpreterProxy stackValue: 2.
	((interpreterProxy isBytes: creatorString) and: [(interpreterProxy byteSizeOf: creatorString) = 4]) ifFalse:[^interpreterProxy primitiveFail].
	((interpreterProxy isBytes: typeString) and: [(interpreterProxy byteSizeOf: typeString) = 4]) ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy isBytes: fileName) ifFalse:[^interpreterProxy primitiveFail].
	creatorStringIndex _ interpreterProxy firstIndexableField: creatorString.
	typeStringIndex _ interpreterProxy firstIndexableField: typeString.
	fileNameIndex _ interpreterProxy firstIndexableField: fileName.
	fileNameSize _ interpreterProxy byteSizeOf: fileName.
	(self cCode: 'dir_GetMacFileTypeAndCreator(
			(char *) fileNameIndex, fileNameSize,
			(char *) typeStringIndex, (char *) creatorStringIndex)'
		inSmalltalk:[true]) ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 3.  "pop filename, type, creator; leave rcvr on stack"
