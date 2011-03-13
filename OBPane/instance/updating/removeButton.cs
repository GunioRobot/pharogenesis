removeButton
	self hasButton 
		ifTrue: [self removeMorph: button.
				button _ nil.
				self adjustList]