floatAt: index put: value
	"For subclasses that override #at:put:"
	<primitive: 'primitiveFloatArrayAtPut'>
	self basicAt: index put: value asIEEE32BitWord.
	^value