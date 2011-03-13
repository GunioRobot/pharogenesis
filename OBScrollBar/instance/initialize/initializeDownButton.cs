initializeDownButton
	downButton := RectangleMorph
		newBounds: (self innerBounds bottomRight - self buttonExtent extent: self buttonExtent)
		color: self thumbColor.
	downButton on: #mouseDown send: #scrollDownInit to: self.
	downButton on: #mouseUp send: #finishedScrolling to: self.
	downButton addMorphCentered: (ImageMorph new image: 
		(self 
			cachedImageAt: (bounds isWide ifTrue: ['right'] ifFalse: ['down']) 
			ifAbsentPut: [
				self upArrow8Bit
					rotateBy: (bounds isWide ifTrue: [#right] ifFalse: [#pi])
					centerAt: 0@0
			]
		)
	).
	self roundedScrollbarLook ifTrue:[
		downButton color: Color veryLightGray.
		downButton borderStyle: (BorderStyle complexRaised width: 3).
	] ifFalse:[
		downButton setBorderWidth: 1 borderColor: #raised.
	].
	self addMorph: downButton.
