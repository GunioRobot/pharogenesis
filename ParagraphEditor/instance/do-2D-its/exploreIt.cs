exploreIt
	| result |
	result _ self evaluateSelection.
	((result isKindOf: FakeClassPool) or: [result == #failedDoit])
			ifTrue: [view flash]
			ifFalse: [result explore].
