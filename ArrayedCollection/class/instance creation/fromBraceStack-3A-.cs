fromBraceStack: itsSize 
	"Answer an instance of me with itsSize elements, popped in reverse order from
	 the stack of thisContext sender.  Do not call directly: this is called by {1. 2. 3}
	 constructs."

	^ (self new: itsSize) fill: itsSize fromStack: thisContext sender