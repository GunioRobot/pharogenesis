startRot: evt with: rotHandle
	"Initialize rotation of my target if it is a kind of SketchMorph."

	(target isKindOf: SketchMorph) ifTrue: [
		growingOrRotating _ true.
		self removeAllHandlesBut: rotHandle.  "remove all other handles"
		angleOffset _ rotHandle center - target referencePosition.
		angleOffset _ Point r: angleOffset r
					degrees: angleOffset degrees - target rotationDegrees].
