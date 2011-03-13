justDroppedInto: newOwner event: evt

	selectedItems isEmpty ifTrue:
		["Hand just clicked down to draw out a new selection"
		^ self extendByHand: evt hand].
	dupLoc ifNotNil: [dupDelta _ self position - dupLoc].
	selectedItems reverseDo: [:m | newOwner addMorphFront: m].
	^ super justDroppedInto: newOwner event: evt