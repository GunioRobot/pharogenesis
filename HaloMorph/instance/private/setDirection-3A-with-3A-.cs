setDirection: anEvent with: directionHandle
	"The user has let up after having dragged the direction arrow; now set the forward direction of the actual SketchMorph accordingly"
	| alphaRadians alphaDegrees targetPlayer delta targetXY |
	targetXY _ target cartesianXY.
	targetPlayer _ target player.
	delta _ innerTarget referencePositionInWorld - directionHandle center.
	alphaRadians _ delta y = 0
		ifTrue:
			[delta x > 0 ifTrue: [3 * Float halfPi] ifFalse: [Float halfPi]]
		ifFalse:
			[delta y > 0
				ifTrue:
					[(delta x negated / delta y) arcTan]
				ifFalse:
					[Float pi - (delta x / delta y) arcTan]].
	alphaDegrees _ alphaRadians radiansToDegrees asSmallPositiveDegrees.
	innerTarget setupAngle: (innerTarget setupAngle - (targetPlayer getHeading - alphaDegrees)) asSmallPositiveDegrees.

	(target isKindOf: TransformationMorph) ifTrue: [target removeFlexShell].
	targetPlayer setHeading: alphaDegrees.
	targetPlayer costume cartesianXY: targetXY.
	self endInteraction