compositionRectangle
	| compRect |
	compRect _ self innerBounds.
	margins ifNotNil: [compRect _ compRect insetBy: margins].
	compRect width < 9 ifTrue: [compRect _ compRect withWidth: 9].
	compRect height < 16 ifTrue: [compRect _ compRect withHeight: 16].
	^ compRect