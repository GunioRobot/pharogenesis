rowsNoWiderThan: maxWidth
	| aPosition neededHeight |
	self fixedWidth: maxWidth.
	verticalPadding ifNil: [verticalPadding _ 4].  "for benefit of old structures"
	aPosition _ self topLeft.
	neededHeight _ self basicHeight.
	submorphs do:
		[:aMorph |
			aMorph position: (aPosition + (padding @ 0)).
			(aMorph right > (self left + maxWidth)) ifTrue:
				[aPosition _ self left @ (aPosition y + neededHeight).
				aMorph position: aPosition + (padding @ 0).
				neededHeight _ self basicHeight].
			aPosition _ aMorph topRight.
			neededHeight _ neededHeight max: aMorph height].
	self extent: (maxWidth @ ((aPosition y + neededHeight) - self top))