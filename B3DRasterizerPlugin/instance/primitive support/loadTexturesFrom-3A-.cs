loadTexturesFrom: stackIndex
	| arrayOop destPtr n textureOop |
	self var: #destPtr declareC:'B3DTexture *destPtr'.
	arrayOop _ interpreterProxy stackObjectValue: stackIndex.
	(interpreterProxy fetchClassOf: arrayOop) == interpreterProxy classArray
		ifFalse:[^interpreterProxy primitiveFail].
	n _ interpreterProxy slotSizeOf: arrayOop.
	n _ n min: (self cCode: 'state.nTextures').
	0 to: n-1 do:[:i|
		destPtr _ self cCode:'state.textures + i'.
		textureOop _ interpreterProxy fetchPointer: i ofObject: arrayOop.
		(self loadTexture: textureOop into: destPtr) 
			ifFalse:[^interpreterProxy primitiveFail].
	].
	^0