floatAt: index
	"For simulation only"
	<primitive: 'primitiveFloatArrayAt'>
	^Float fromIEEE32Bit: (self basicAt: index)