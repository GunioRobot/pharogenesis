primitiveBeDisplay
	"Record the system Display object in the specialObjectsTable."
	| rcvr |
	rcvr _ self stackTop.
	self success: ((self isPointers: rcvr) and: [(self lengthOf: rcvr) >= 4]).
	successFlag ifTrue: [self storePointer: TheDisplay ofObject: specialObjectsOop withValue: rcvr]