exploreIt

	| result |
	self handleEdit: [
		result := textMorph editor evaluateSelection.
		((result isKindOf: FakeClassPool) or: [result == #failedDoit])
			ifTrue: [self flash]
			ifFalse: [result explore]].