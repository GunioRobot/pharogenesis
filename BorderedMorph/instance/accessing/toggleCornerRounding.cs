toggleCornerRounding
	self cornerStyle == #rounded
		ifTrue: [self useSquareCorners]
		ifFalse: [self useRoundedCorners].
	self changed