rotationDegrees: degrees
	| m |
	self adjustAfter:
		[(m _ self renderedMorph) doesOwnRotation
			ifTrue: ["is SketchMorph and rotationStyle is not #normal"
				m rotationDegrees: degrees.
				"self angle: 0.0 or not flexed"]
			ifFalse: [self angle: degrees degreesToRadians negated]]	"usual case"