getHeadingUnrounded
 
	costume isFlexMorph
		ifTrue: [^ costume rotationDegrees asSmallAngleDegrees]
		ifFalse: [^ 0.0].
