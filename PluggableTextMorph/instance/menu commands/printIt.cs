printIt
	| result |
	self handleEdit:
		[result _ textMorph editor evaluateSelection.
		((result isKindOf: FakeClassPool) or: [result == #failedDoit])
			ifTrue: [self flash]
			ifFalse: [textMorph editor afterSelectionInsertAndSelect: result printString]]