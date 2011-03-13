standardPlayer
	standardPlayer ifNil:
		[self createStandardPlayer].
	standardPlayer costume isInWorld ifFalse: [associatedMorph addMorphFront: standardPlayer costume].
	^ standardPlayer