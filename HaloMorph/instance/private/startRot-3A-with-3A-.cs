startRot: evt with: rotHandle
	"Initialize rotation of my target if it is rotatable."

	target isFlexMorph ifFalse: [target addFlexShell].
	growingOrRotating _ true.
	self removeAllHandlesBut: rotHandle.  "remove all other handles"
	angleOffset _ rotHandle center - target referencePosition.
	angleOffset _
		Point
			r: angleOffset r
			degrees: angleOffset degrees - target rotationDegrees.
