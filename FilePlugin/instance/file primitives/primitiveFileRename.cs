primitiveFileRename
	| oldNamePointer newNamePointer oldNameIndex oldNameSize newNameIndex newNameSize  okToRename |
	self var: 'oldNameIndex' type: 'char *'.
	self var: 'newNameIndex' type: 'char *'.
	self export: true.
	newNamePointer _ interpreterProxy stackValue: 0.
	oldNamePointer _ interpreterProxy stackValue: 1.
	((interpreterProxy isBytes: newNamePointer)
			and: [interpreterProxy isBytes: oldNamePointer])
		ifFalse: [^ interpreterProxy primitiveFail].
	newNameIndex _ interpreterProxy firstIndexableField: newNamePointer.
	newNameSize _ interpreterProxy byteSizeOf: newNamePointer.
	oldNameIndex _ interpreterProxy firstIndexableField: oldNamePointer.
	oldNameSize _ interpreterProxy byteSizeOf: oldNamePointer.
	"If the security plugin can be loaded, use it to check for rename 
	permission.
	If not, assume it's ok"
	sCRFfn ~= 0
		ifTrue: [okToRename _ self cCode: ' ((int (*) (char *, int)) sCRFfn)(oldNameIndex, oldNameSize)'.
			okToRename
				ifFalse: [^ interpreterProxy primitiveFail]].
	self
		sqFileRenameOld: (self cCoerce: oldNameIndex to: 'int')
		Size: oldNameSize
		New: (self cCoerce: newNameIndex to: 'int')
		Size: newNameSize.
	interpreterProxy failed
		ifFalse: [interpreterProxy pop: 2]