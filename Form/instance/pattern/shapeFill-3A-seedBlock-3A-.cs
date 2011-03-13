shapeFill: aColor seedBlock: seedBlock
	depth > 1 ifTrue: [self halt]. "Only meaningful for B/W forms."
	(self findShapeAroundSeedBlock: seedBlock)
		displayOn: self at: 0@0 clippingBox: self boundingBox
		rule: Form under fillColor: aColor 