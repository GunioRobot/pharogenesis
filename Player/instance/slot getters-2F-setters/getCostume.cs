getCostume
	"Answer a form representing the receiver's primary graphic.  An earlier wording, disused but may persist in preexisting scripts."

	| aMorph |
	^ ((aMorph _ costume renderedMorph) isSketchMorph)
		ifTrue:
			[aMorph form]
		ifFalse:
			[aMorph imageForm]