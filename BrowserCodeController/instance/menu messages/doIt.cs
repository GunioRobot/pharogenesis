doIt
	"Allow class variables and pool variables of current class to be accessed in the doIt"
	| result |
	model selectedClass == nil ifTrue: [^ super doIt].
	FakeClassPool classPool: model selectedClass classPool.
	FakeClassPool sharedPools: model selectedClass sharedPools.
	result _ super doIt.
	FakeClassPool classPool: nil.
	FakeClassPool sharedPools: nil.
	^ result