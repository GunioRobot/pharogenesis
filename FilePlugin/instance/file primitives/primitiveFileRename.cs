primitiveFileRename

	| oldNamePointer newNamePointer oldNameIndex oldNameSize newNameIndex newNameSize |
	self var: 'oldNameIndex' type: 'char *'.
	self var: 'newNameIndex' type: 'char *'.
	self export: true.
	newNamePointer _ interpreterProxy stackValue: 0.
	oldNamePointer _ interpreterProxy stackValue: 1.
	((interpreterProxy isBytes: newNamePointer) and:[
		(interpreterProxy isBytes: oldNamePointer)])
			ifFalse:[^interpreterProxy primitiveFail].

	newNameIndex _ interpreterProxy firstIndexableField: newNamePointer.
	newNameSize _ interpreterProxy byteSizeOf: newNamePointer.
	oldNameIndex _ interpreterProxy firstIndexableField: oldNamePointer.
	oldNameSize _ interpreterProxy byteSizeOf: oldNamePointer.
	self sqFileRenameOld: (self cCoerce: oldNameIndex to: 'int') Size: oldNameSize New: (self cCoerce: newNameIndex to: 'int') Size: newNameSize.
	interpreterProxy failed ifFalse:[
		interpreterProxy pop: 2.  "pop new and old names, leave rcvr on stack"
	].