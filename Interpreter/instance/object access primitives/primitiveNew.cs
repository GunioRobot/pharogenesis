primitiveNew
	"Allocate a new fixed-size instance. Fail if the allocation would leave less than lowSpaceThreshold bytes free."

	| class spaceOkay |
	class _ self stackValue: 0.
	"The following may cause GC!"
	spaceOkay _ self sufficientSpaceToInstantiate: class indexableSize: 0.
	self success: spaceOkay.
	successFlag
		ifTrue: [ self push: (self instantiateClass: self popStack indexableSize: 0) ]