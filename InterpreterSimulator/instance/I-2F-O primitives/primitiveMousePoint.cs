primitiveMousePoint

	| relPt |
	self pop: 1.
	displayForm == nil
		ifTrue: [self push: (self makePointwithxValue: 99 yValue: 66)]
		ifFalse: [relPt _ Sensor cursorPoint - (Display extent - displayForm extent - (10@10)).
				self push: (self makePointwithxValue: relPt x yValue: relPt y)]