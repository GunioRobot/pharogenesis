loadFloatOrIntFrom: floatOrInt
	"If floatOrInt is an integer, then convert it to a C double float and return it.
	If it is a Float, then load its value and return it.
	Otherwise fail -- ie return with successFlag set to false."

	self inline: true.
	self returnTypeC: 'double'.

	(self isIntegerObject: floatOrInt) ifTrue:
		[^ self cCode: '((double) (floatOrInt >> 1))'
				inSmalltalk: [(self integerValueOf: floatOrInt) asFloat]].
	(self fetchClassOfNonInt: floatOrInt) = (self splObj: ClassFloat)
		ifTrue: [^ self floatValueOf: floatOrInt].
	successFlag _ false