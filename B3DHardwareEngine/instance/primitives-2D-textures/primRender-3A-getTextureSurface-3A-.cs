primRender: rendererHandle getTextureSurface: textureHandle
	"Primitive. Return the texture's surface handle for blitting from within Squeak.
	Fail if the surface cannot be accessed directly."
	<primitive:'primitiveTextureSurfaceHandle' module:'B3DAcceleratorPlugin'>
	^nil