morphAsPostscript: aMorph rotated: rotateFlag offsetBy: offset

	self reset.
	psBounds _ offset extent: aMorph bounds extent.
	topLevelMorph _ aMorph.
	self writeHeaderRotated: rotateFlag.
	self fullDrawMorph: aMorph.

	^self close

