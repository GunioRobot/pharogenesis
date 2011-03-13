tileForIt
	"Return a tile referring to the object resulting form evaluating my current selection.  Not currently threaded in, but useful in earlier demos and possibly still of value."

	| result |
	self handleEdit:
		[result _ textMorph editor evaluateSelection.
		((result isKindOf: FakeClassPool) or: [result == #failedDoit])
			ifTrue: [self flash]
			ifFalse: [self currentHand attachMorph: result tileToRefer]]