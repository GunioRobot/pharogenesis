primitiveNew
	"Allocate a new fixed-size instance. Fail if the allocation would leave less than lowSpaceThreshold bytes free."

	| class spaceOkay |
	class _ self popStack.
	spaceOkay _ self sufficientSpaceToInstantiate: class indexableSize: 0.
	self success: spaceOkay.
	successFlag
		ifTrue: [ self push: (self instantiateClass: class indexableSize: 0) ]
		ifFalse: [ self unPop: 1 ].