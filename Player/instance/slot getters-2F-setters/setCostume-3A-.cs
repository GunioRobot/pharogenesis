setCostume: aForm
	"Set the receiver's graphic as indicated.  An earlier wording, disused but may persist in preexisting scripts."

	| aMorph |
	^ ((aMorph _ costume renderedMorph) isSketchMorph)
		ifTrue:
			[aMorph form: aForm]
		ifFalse:
			["what to do?"]