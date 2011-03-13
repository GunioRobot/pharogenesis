inspectIt
	"Allow class variables and pool variables of current class to be accessed in the inspectIt.  6/13/96 sw"

	| result |

	model selectedClass == nil ifTrue: [^ super inspectIt].
	FakeClassPool classPool: model selectedClass classPool.
	FakeClassPool sharedPools: model selectedClass sharedPools.
	self controlTerminate.

	result _ self evaluateSelection.
	FakeClassPool classPool: nil.
	FakeClassPool sharedPools: nil.

	((result isKindOf: FakeClassPool) or:
		[result == #failedDoit])
			ifFalse: [result inspect]
			ifTrue: [view flash].
	self controlInitialize.

	^ result