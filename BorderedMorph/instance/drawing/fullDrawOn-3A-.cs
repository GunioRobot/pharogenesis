fullDrawOn: aCanvas
	self wantsRoundedCorners
		ifTrue:
			[self fullDrawWithRoundedCornersOn: aCanvas]
		ifFalse:
			[super fullDrawOn: aCanvas]