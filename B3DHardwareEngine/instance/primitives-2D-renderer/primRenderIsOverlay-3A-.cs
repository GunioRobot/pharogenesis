primRenderIsOverlay: aHandle
	"Primitive. Return true if the receiver is represented by a native window and Squeak cannot draw on top of it. On some systems (for instance Mac) it is possible to draw on top of the rendering target although it may be bound to a window. On others (like Windows and AFAIK most Unix systems) it is impossible to draw on top of a rendering context that is directly bound to a window."
	<primitive:'primitiveIsOverlayRenderer' module: 'B3DAcceleratorPlugin'>
	^nil