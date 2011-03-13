justDroppedInto: aMorph event: anEvent

	self setProperty: #stickToTop toValue: nil.
	self positionVertically.
	LastManualPlacement _ {self position. self valueOfProperty: #stickToTop}.
	super justDroppedInto: aMorph event: anEvent.
	self step