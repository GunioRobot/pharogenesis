initializeUpButton
	upButton := RectangleMorph
		newBounds: ((bounds isWide ifTrue: [menuButton bounds topRight]
									ifFalse: [menuButton bounds bottomLeft])
					extent: self buttonExtent)
		color: Color lightGray.
	upButton on: #mouseDown send: #borderInset to: upButton.
	upButton on: #mouseStillDown send: #scrollUp to: self.
	upButton on: #mouseUp send: #borderRaised to: upButton.
	upButton addMorphCentered: (ImageMorph new image: 
		(bounds isWide ifTrue: [UpArrow rotateBy: #left centerAt: 0@0] ifFalse: [UpArrow])).
	upButton setBorderWidth: 2 borderColor: #raised.
	self addMorph: upButton