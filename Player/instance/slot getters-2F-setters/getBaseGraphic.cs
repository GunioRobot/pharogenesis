getBaseGraphic
	"Answer a form representing the receiver's base graphic"

	| aMorph |
	^ ((aMorph _ costume renderedMorph) isSketchMorph)
		ifTrue:
			[aMorph baseGraphic]
		ifFalse:
			[aMorph imageForm]