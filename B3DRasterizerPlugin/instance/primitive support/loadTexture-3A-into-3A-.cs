loadTexture: textureOop into: destPtr
	"Note: This still uses the old-style textures"
	| form formBits formWidth formHeight formDepth texWrap texInterpolate texEnvMode bitsPtr |
	self var: #bitsPtr declareC:'void *bitsPtr'.
	self var: #destPtr declareC:'B3DTexture *destPtr'.
	"Fetch and validate the form"
	form _ textureOop.
	(interpreterProxy isPointers: form) ifFalse:[^false].
	(interpreterProxy slotSizeOf: form) < 8 ifTrue:[^false].
	formBits _ interpreterProxy fetchPointer: 0 ofObject: form.
	formWidth _ interpreterProxy fetchInteger: 1 ofObject: form.
	formHeight _ interpreterProxy fetchInteger: 2 ofObject: form.
	formDepth _ interpreterProxy fetchInteger: 3 ofObject: form.
	texWrap _ interpreterProxy booleanValueOf: 
		(interpreterProxy fetchPointer: 5 ofObject: form).
	texInterpolate _ interpreterProxy booleanValueOf: 
		(interpreterProxy fetchPointer: 6 ofObject: form).
	texEnvMode _ interpreterProxy fetchInteger: 7 ofObject: form.
	interpreterProxy failed ifTrue:[^false].
	(formWidth < 1 or:[formHeight < 1 or:[formDepth ~= 32]]) ifTrue:[^false].
	(interpreterProxy fetchClassOf: formBits) = interpreterProxy classBitmap ifFalse:[^false].
	(interpreterProxy byteSizeOf: formBits) = (formWidth * formHeight * 4) ifFalse:[^false].
	(texEnvMode < 0 or:[texEnvMode > 1]) ifTrue:[^false].

	"Now fetch the bits"
	bitsPtr _ interpreterProxy firstIndexableField: formBits.
	"Set the texture parameters"
	^self cCode:'b3dLoadTexture(destPtr, formWidth, formHeight, formDepth, (unsigned int*) bitsPtr, 0, NULL) == B3D_NO_ERROR'.