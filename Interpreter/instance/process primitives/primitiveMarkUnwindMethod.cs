primitiveMarkUnwindMethod
	"Primitive. Mark the method for exception unwinding. The primitive must fail after marking the context so that the regular code is run."
	self inline: false.
	^self primitiveFail