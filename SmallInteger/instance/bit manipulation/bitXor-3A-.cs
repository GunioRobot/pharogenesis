bitXor: arg 
	"Primitive. Answer an Integer whose bits are the logical XOR of the
	receiver's bits and those of the argument, arg.
	Negative numbers are interpreted as a 32-bit 2's-complement.
	Essential.  See Object documentation whatIsAPrimitive."

	<primitive: 16>
	self < 0 ifTrue: [^ 16rFFFFFFFF + (self+1) bitXor: arg].
	^arg bitXor: self