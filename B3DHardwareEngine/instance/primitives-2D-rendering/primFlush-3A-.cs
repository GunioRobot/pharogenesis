primFlush: aHandle
	"Primitive. If any rendering operations are pending, force them to be executed.
	Do not wait until they have taken effect."
	<primitive: 'primitiveFlushRenderer' module:'B3DAcceleratorPlugin'>
	^nil