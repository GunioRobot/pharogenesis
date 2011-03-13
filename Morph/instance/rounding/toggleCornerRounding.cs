toggleCornerRounding
	self wantsRoundedCorners
		ifTrue: [self removeProperty: #roundedCorners]
		ifFalse: [self setProperty: #roundedCorners toValue: true].
	self changed