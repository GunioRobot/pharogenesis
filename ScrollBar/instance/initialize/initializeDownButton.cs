initializeDownButton
	downButton := RectangleMorph
		newBounds: (self innerBounds bottomRight - self buttonExtent extent: self buttonExtent)
		color: Color lightGray.
	downButton on: #mouseDown send: #borderInset to: downButton.
	downButton on: #mouseStillDown send: #scrollDown to: self.
	downButton on: #mouseUp send: #borderRaised to: downButton.
	downButton addMorphCentered: (ImageMorph new image: 
		(UpArrow rotateBy: (bounds isWide ifTrue: [#right] ifFalse: [#pi]) centerAt: 0@0)).
	downButton setBorderWidth: 2 borderColor: #raised.
	self addMorph: downButton