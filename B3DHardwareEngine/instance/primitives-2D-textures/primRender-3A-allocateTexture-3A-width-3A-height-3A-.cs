primRender: aHandle allocateTexture: d width: w height: h
	"Primitive. Allocate a texture with the given dimensions.
	Note: The depth of the texture allocated may *not* match the specified values here."
	<primitive:'primitiveAllocateTexture' module:'B3DAcceleratorPlugin'>
	^nil