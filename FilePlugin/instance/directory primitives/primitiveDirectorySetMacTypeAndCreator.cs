primitiveDirectorySetMacTypeAndCreator
	| creatorString typeString fileName creatorStringIndex typeStringIndex fileNameIndex fileNameSize  okToSet |
	self var: 'creatorStringIndex' type: 'char *'.
	self var: 'typeStringIndex' type: 'char *'.
	self var: 'fileNameIndex' type: 'char *'.
	self export: true.
	creatorString _ interpreterProxy stackValue: 0.
	typeString _ interpreterProxy stackValue: 1.
	fileName _ interpreterProxy stackValue: 2.
	((interpreterProxy isBytes: creatorString)
			and: [(interpreterProxy byteSizeOf: creatorString)
					= 4])
		ifFalse: [^ interpreterProxy primitiveFail].
	((interpreterProxy isBytes: typeString)
			and: [(interpreterProxy byteSizeOf: typeString)
					= 4])
		ifFalse: [^ interpreterProxy primitiveFail].
	(interpreterProxy isBytes: fileName)
		ifFalse: [^ interpreterProxy primitiveFail].
	creatorStringIndex _ interpreterProxy firstIndexableField: creatorString.
	typeStringIndex _ interpreterProxy firstIndexableField: typeString.
	fileNameIndex _ interpreterProxy firstIndexableField: fileName.
	fileNameSize _ interpreterProxy byteSizeOf: fileName.
	"If the security plugin can be loaded, use it to check for permission.
	If 
	not, assume it's ok"
	sCSFTfn ~= 0
		ifTrue: [okToSet _ self cCode: ' ((int (*) (char *, int)) sCSFTfn)(fileNameIndex, fileNameSize)'.
			okToSet
				ifFalse: [^ interpreterProxy primitiveFail]].
	(self
			cCode: 'dir_SetMacFileTypeAndCreator(
			(char *) fileNameIndex, fileNameSize,
			(char *) typeStringIndex, (char *) creatorStringIndex)'
			inSmalltalk: [true])
		ifFalse: [^ interpreterProxy primitiveFail].
	interpreterProxy pop: 3