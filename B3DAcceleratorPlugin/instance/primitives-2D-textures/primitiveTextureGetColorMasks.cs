primitiveTextureGetColorMasks
	| handle result masks array |
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
	result _ self cCode:'b3dxTextureColorMasks(handle, masks)' inSmalltalk:[false].
	result ifFalse:[^interpreterProxy primitiveFail].
	0 to: 3 do:[:i|
		interpreterProxy storePointer: i ofObject: array withValue:
			(interpreterProxy positive32BitIntegerFor: (masks at: i))].
	interpreterProxy pop: 2. "pop args return receiver"