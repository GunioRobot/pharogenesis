forwardDirection
	"The direction I will go when issued a sent forward:.  Up is zero.
Clockwise like a compass."

^ (self valueOfProperty: #forwardDirection) ifNil: [0.0]