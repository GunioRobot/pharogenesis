b3dPrimitiveTextureSize
	"Primitive. Return the minimal number of words needed for a primitive object."
	| objSize |
	self export: true.
	self inline: false.
	objSize _ (self cCode:'sizeof(B3DTexture)') // 4 + 1.
	interpreterProxy pop: 1.
	interpreterProxy pushInteger: objSize.