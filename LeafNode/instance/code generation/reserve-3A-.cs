reserve: encoder 
	"If this is a yet unused literal of type -code, reserve it."

	self code < 0 ifTrue: [self code: (self code: (encoder litIndex: self key) type: 0 - self code)]