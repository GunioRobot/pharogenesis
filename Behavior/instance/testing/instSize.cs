instSize
	"Answer the number of named instance variables
	(as opposed to indexed variables) of the receiver."

	^ ((format bitShift: -1) bitAnd: 16r3F) - 1