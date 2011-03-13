quo: anInteger 
	"Primitive. Divide the receiver by the argument and return the result.
	Round the result down towards zero to make it a whole integer. Fail if
	the argument is 0. Fail if either the argument or the result is not a
	SmallInteger or a LargePositiveInteger less than 65536. Optional. See
	Object documentation whatIsAPrimitive."

	<primitive: 33>
	^super quo: anInteger