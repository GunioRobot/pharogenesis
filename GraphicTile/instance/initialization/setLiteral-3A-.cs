setLiteral: anObject
	"Set the receiver's literal to be anObject. No readout morph here."

	type _ #literal.
	self setLiteralInitially: anObject.
