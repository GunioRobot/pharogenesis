primFlush: aHandle
	"Primitive. If any rendering operations are pending, force them to be executed.
	Do not wait until they have taken effect."
	<primitive: 'primitiveFlushDisplaySurface' module:'Squeak3DX'>
	^nil