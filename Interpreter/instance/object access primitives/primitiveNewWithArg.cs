primitiveNewWithArg
	"Allocate a new indexable instance. Fail if the allocation would leave less than lowSpaceThreshold bytes free."

	| size class spaceOkay |
	size _ self positive32BitValueOf: (self stackValue: 0).
	class _ self stackValue: 1.
	self success: size >= 0.
	successFlag ifTrue: [
		"The following may cause GC!"
		spaceOkay _ self sufficientSpaceToInstantiate: class indexableSize: size.
		self success: spaceOkay.
		class _ self stackValue: 1. "Reload class in case of GC"
	].
	successFlag
		ifTrue: [ self pop: 2 thenPush: (self instantiateClass: class indexableSize: size) ]