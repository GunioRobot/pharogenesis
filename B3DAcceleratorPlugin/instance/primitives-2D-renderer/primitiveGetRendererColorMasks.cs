primitiveGetRendererColorMasks
	| handle result masks array arrayOop |
	self export: true.
	self var: #masks declareC:'int masks[4]'.
	interpreterProxy methodArgumentCount = 2
		ifFalse:[^interpreterProxy primitiveFail].
	array _ interpreterProxy stackObjectValue: 0.
	handle _ interpreterProxy stackIntegerValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy fetchClassOf: array) = interpreterProxy classArray
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy slotSizeOf: array) = 4
		ifFalse:[^interpreterProxy primitiveFail].
	result _ self cCode:'b3dxGetRendererColorMasks(handle, masks)' inSmalltalk:[false].
	result ifFalse:[^interpreterProxy primitiveFail].
	arrayOop _ array.
	0 to: 3 do:[:i|
		interpreterProxy pushRemappableOop: arrayOop.
		result _ interpreterProxy positive32BitIntegerFor: (masks at: i).
		arrayOop _ interpreterProxy popRemappableOop.
		interpreterProxy storePointer: i ofObject: arrayOop withValue: result].
	^interpreterProxy pop: 2. "pop args return receiver"