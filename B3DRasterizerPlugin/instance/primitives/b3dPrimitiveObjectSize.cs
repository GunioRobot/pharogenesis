b3dPrimitiveObjectSize
	"Primitive. Return the minimal number of words needed for a primitive object."
	| objSize |
	self export: true.
	self inline: false.
	objSize _ (self cCode:'sizeof(B3DPrimitiveObject) + sizeof(B3DPrimitiveVertex)') // 4 + 1.
	interpreterProxy pop: 1.
	interpreterProxy pushInteger: objSize.