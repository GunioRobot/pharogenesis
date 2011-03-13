addOrRemoveItems: handOrEvent
	"Make a new selection extending the current one."

	| oldOwner hand |
	hand _ (handOrEvent isKindOf: HandMorph)
			ifTrue: [handOrEvent]
			ifFalse: [handOrEvent hand].
	hand addMorphBack: ((SelectionMorph newBounds: (hand lastEvent cursorPoint extent: 16@16))
							setOtherSelection: self).
	oldOwner _ owner.
	self world abandonAllHalos.  "Will delete me"
	oldOwner addMorph: self.