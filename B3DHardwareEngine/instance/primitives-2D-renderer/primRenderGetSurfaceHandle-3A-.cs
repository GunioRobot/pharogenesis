primRenderGetSurfaceHandle: aHandle
	"Primitive. If this renderer is associated with a surface that we can blt directly to, return the surface handle for it. This is usually the case if the receiver is rendering to some offscreen target device (OpenGL p-buffers; DirectDraw surfaces)."
	<primitive:'primitiveGetRendererSurfaceHandle' module: 'B3DAcceleratorPlugin'>
	^nil