setBaseGraphic: aGraphic
	"Set the base graphic"

	| aMorph |
	^ ((aMorph _ costume renderedMorph) isSketchMorph)
		ifTrue:
			[aMorph baseGraphic: aGraphic]