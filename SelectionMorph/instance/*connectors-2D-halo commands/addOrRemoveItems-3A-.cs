addOrRemoveItems: handOrEvent 
	"Make a new selection extending the current one."

	| oldOwner hand |
	hand := (handOrEvent isMorphicEvent) 
				ifFalse: [handOrEvent]
				ifTrue: [handOrEvent hand].
	hand 
		addMorphBack: ((self class 
				newBounds: (hand lastEvent cursorPoint extent: 16 @ 16)) 
					setOtherSelection: self).
	oldOwner := owner.
	self world abandonAllHalos.	"Will delete me"
	oldOwner addMorph: self