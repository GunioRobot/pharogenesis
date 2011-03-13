mouseMove: evt
	"Copied from TileMorph mouseMove to use literal:width: rather than literal:."

	| p label |
	upArrow ifNotNil:
		[p _ evt cursorPoint.
		label _ self findA: UpdatingStringMorph.
		label ifNotNil: [literal _ label valueFromContents].
		(upArrow containsPoint: p)
			ifTrue: [self readyForAnotherTick ifTrue:
				[self literal: (self numericValue + 1) width: label width.
				^ self]].

		(downArrow containsPoint: p)
			ifTrue: [self readyForAnotherTick ifTrue:
				[self literal: (self numericValue - 1) width: label width.
				^ self]]].

	super mouseMove: evt.
