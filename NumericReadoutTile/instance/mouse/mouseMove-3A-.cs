mouseMove: evt
	"Copied from TileMorph mouseMove to use literal:width: rather than literal:."

	| p label |
	upArrow ifNotNil:
		[p _ evt cursorPoint.
		self abandonLabelFocus.
		label _ self findA: UpdatingStringMorph.

		label ifNotNil:
			[label step. literal _ label valueFromContents].

		(upArrow containsPoint: p)
			ifTrue: [self variableDelay:
						[self literal: (self numericValue + 1).
						self resizeToFitLabel].
					^ evt hand noteSignificantEvent: evt].
		(downArrow containsPoint: p)
			ifTrue: [self variableDelay:
						[self literal: (self numericValue - 1).
						self resizeToFitLabel].
					^ evt hand noteSignificantEvent: evt]].

	super mouseMove: evt.
