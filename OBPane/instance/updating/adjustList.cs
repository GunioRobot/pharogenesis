adjustList
	self hasButton
			ifFalse: [list bounds: self innerBounds]
			ifTrue: [list bounds: (self innerBounds withHeight: (self height - self buttonHeight))]