primitiveBeDisplay
	"Record the system Display object."

	| rcvr |
	rcvr _ self stackTop.
	self success: ((self isPointers: rcvr) and: [(self lengthOf: rcvr) >= 4]).
	successFlag ifTrue: [
		"record the display object both in a variable and in the specialObjectsOop"
		self storePointer: TheDisplay ofObject: specialObjectsOop withValue: rcvr.
	].