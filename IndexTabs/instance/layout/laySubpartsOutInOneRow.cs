laySubpartsOutInOneRow
	| aPosition neededHeight widthToUse mid |
	fixedWidth ifNotNil: [self error: 'incompatibility in IndexTabs'].
	verticalPadding ifNil: [verticalPadding _ 4].  "for benefit of old structures"
	aPosition _ self topLeft.
	neededHeight _ self basicHeight.
	submorphs do:
		[:aMorph |
			aMorph position: (aPosition + (padding @ 0)).
			aPosition _ aMorph topRight.
			neededHeight _ neededHeight max: aMorph height].
	neededHeight _ neededHeight + (verticalPadding * 2).
	mid _ self top + (neededHeight // 2).
	submorphs do:
		[:aMorph |
			aMorph top: (mid - (aMorph height // 2))].
	widthToUse _ self widthImposedByOwner max: self requiredWidth.
	self extent: (((aPosition x + padding - self left) max: widthToUse) @ neededHeight)