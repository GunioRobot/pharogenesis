primRender: aHandle getColorMasksInto: anArray
	"Primitive. If this renderer is associated with a surface that we can blt directly to, return the color masks for it."
	<primitive:'primitiveGetRendererColorMasks' module: 'B3DAcceleratorPlugin'>
	^nil