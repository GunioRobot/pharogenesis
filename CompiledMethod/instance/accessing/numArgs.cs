numArgs
	"Answer the number of arguments the receiver takes."

	^ (self header bitShift: -24) bitAnd: 16r1F