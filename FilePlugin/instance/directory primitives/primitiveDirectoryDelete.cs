primitiveDirectoryDelete

	| dirName dirNameIndex dirNameSize |
	self var: #dirNameIndex type: 'char *'.
	self export: true.
	dirName _ interpreterProxy stackValue: 0.
	(interpreterProxy isBytes: dirName) ifFalse:[^interpreterProxy primitiveFail].
	dirNameIndex _ interpreterProxy firstIndexableField: dirName.
	dirNameSize _ interpreterProxy byteSizeOf: dirName.
	(self cCode: 'dir_Delete((char *) dirNameIndex, dirNameSize)'
		inSmalltalk:[false])
		ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: 1.  "pop dirName; leave rcvr on stack"