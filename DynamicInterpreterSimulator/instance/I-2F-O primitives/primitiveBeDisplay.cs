primitiveBeDisplay
	"Extended to create a scratch Form for use by showDisplayBits."

	| rcvr destWidth destHeight destDepth |
	rcvr _ self stackTop.
	self success: ((self isPointers: rcvr) and: [(self lengthOf: rcvr) >= 4]).
	successFlag ifTrue: [
		destWidth _ self fetchInteger: 1 ofObject: rcvr.
		destHeight _ self fetchInteger: 2 ofObject: rcvr.
		destDepth _ self fetchInteger: 3 ofObject: rcvr.
	].
	successFlag ifTrue: [
		"create a scratch form the same size as Smalltalk displayObj"
		displayForm _ Form extent: destWidth @ destHeight
							depth: destDepth.
	].
	super primitiveBeDisplay.