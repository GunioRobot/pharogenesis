primitiveLoadInstVar
	| thisReceiver |
	thisReceiver _ self popStack.
	self push: (self fetchPointer: primitiveIndex-264 ofObject: thisReceiver)