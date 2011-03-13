bitShift: arg 
	"Primitive. Answer an Integer whose value is the receiver's value shifted
	left by the number of bits indicated by the argument. Negative arguments
	shift right.
	Essential.  See Object documentation whatIsAPrimitive."

	<primitive: 17>
	self < 0 ifTrue: [^ -1 - (-1-self bitShift: arg)].
	^ super bitShift: arg