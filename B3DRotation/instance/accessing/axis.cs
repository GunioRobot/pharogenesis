axis
	| sinAngle |
	sinAngle := self a arcCos sin.
	sinAngle isZero ifTrue:[^B3DVector3 zero].
	^B3DVector3 
		x: (self b / sinAngle)
		y: (self c / sinAngle)
		z: (self d / sinAngle)