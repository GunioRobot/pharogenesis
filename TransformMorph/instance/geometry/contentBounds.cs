contentBounds
	self hasSubmorphs ifTrue:
		[^ (transform localBoundsToGlobal: self submorphBounds) truncated].
	^ self fullBounds