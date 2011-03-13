initializeUpButton
	upButton := RectangleMorph
		newBounds: ((menuButton ifNil: [self innerBounds topLeft]
				ifNotNil: [bounds isWide ifTrue: [menuButton bounds topRight]
									ifFalse: [menuButton bounds bottomLeft]])
					extent: self buttonExtent)
		color: Color lightGray.
	upButton on: #mouseDown send: #scrollUpInit to: self.
	upButton on: #mouseUp send: #finishedScrolling to: self.
	upButton addMorphCentered: (ImageMorph new image:
		(self 
			cachedImageAt: (bounds isWide ifTrue: ['left'] ifFalse: ['up'])
			ifAbsentPut: [
				bounds isWide ifTrue: [
					self upArrow8Bit rotateBy: #left centerAt: 0@0
				] ifFalse: [
					self upArrow8Bit
				]
			]
		)
	).
	upButton setBorderWidth: 1 borderColor: #raised.
	self addMorph: upButton