floatAt: index
	"For subclasses that override #at:"
	<primitive: 'primitiveFloatArrayAt'>
	^Float fromIEEE32Bit: (self basicAt: index)