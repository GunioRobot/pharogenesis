restoreBaseGraphic
	"Restore my base graphic"

	| cos |
	((cos _ self costume renderedMorph) isSketchMorph)
		ifTrue:
			[cos restoreBaseGraphic]