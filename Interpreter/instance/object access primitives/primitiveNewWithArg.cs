primitiveNewWithArg
	"Allocate a new indexable instance. Fail if the allocation would leave less than lowSpaceThreshold bytes free."

	| size class spaceOkay |
	size _ self popInteger.
	class _ self popStack.
	self success: size >= 0.
	successFlag ifTrue: [
		spaceOkay _ self sufficientSpaceToInstantiate: class indexableSize: size.
		self success: spaceOkay.
	].
	successFlag
		ifTrue: [ self push: (self instantiateClass: class indexableSize: size) ]
		ifFalse: [ self unPop: 2 ].