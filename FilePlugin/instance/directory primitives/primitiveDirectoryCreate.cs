primitiveDirectoryCreate
	| dirName dirNameIndex dirNameSize okToCreate |
	self var: #dirNameIndex type: 'char *'.
	self export: true.
	dirName _ interpreterProxy stackValue: 0.
	(interpreterProxy isBytes: dirName)
		ifFalse: [^ interpreterProxy primitiveFail].
	dirNameIndex _ interpreterProxy firstIndexableField: dirName.
	dirNameSize _ interpreterProxy byteSizeOf: dirName.
	"If the security plugin can be loaded, use it to check for permission.
	If 
	not, assume it's ok"
	sCCPfn ~= 0
		ifTrue: [okToCreate _ self cCode: ' ((int (*) (char *, int)) sCCPfn)(dirNameIndex, dirNameSize)'.
			okToCreate
				ifFalse: [^ interpreterProxy primitiveFail]].
	(self
			cCode: 'dir_Create((char *) dirNameIndex, dirNameSize)'
			inSmalltalk: [false])
		ifFalse: [^ interpreterProxy primitiveFail].
	interpreterProxy pop: 1