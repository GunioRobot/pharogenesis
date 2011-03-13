initializeUpButton
"initialize the receiver's upButton"
	upButton _ self roundedScrollbarLook
		ifTrue: [RectangleMorph
						newBounds: (self innerBounds topLeft extent: self buttonExtent)]
		ifFalse: [RectangleMorph
						newBounds: ((menuButton
								ifNil: [self innerBounds topLeft]
								ifNotNil: [bounds isWide
										ifTrue: [menuButton bounds topRight]
										ifFalse: [menuButton bounds bottomLeft]])
								extent: self buttonExtent)].
	upButton color: self thumbColor.
	upButton
		on: #mouseDown
		send: #scrollUpInit
		to: self.
	upButton
		on: #mouseUp
		send: #finishedScrolling
		to: self.
	self updateUpButtonImage.
	self roundedScrollbarLook
		ifTrue: [upButton color: Color veryLightGray.
			upButton
				borderStyle: (BorderStyle complexRaised width: 3)]
		ifFalse: [upButton setBorderWidth: 1 borderColor: Color lightGray].
	self addMorph: upButton