initializeUpButton
	upButton := self roundedScrollbarLook 
				ifTrue:  
					[RectangleMorph 
						newBounds: (self innerBounds topLeft extent: self buttonExtent)]
				ifFalse: 
					[RectangleMorph 
						newBounds: ((self innerBounds topLeft) extent: self buttonExtent)].
	upButton color: self thumbColor.
	upButton 
		on: #mouseDown
		send: #scrollUpInit
		to: self.
	upButton 
		on: #mouseUp
		send: #finishedScrolling
		to: self.
	upButton 
		addMorphCentered: (ImageMorph new image: (self 
						cachedImageAt: (bounds isWide ifTrue: ['left'] ifFalse: ['up'])
						ifAbsentPut: 
							[bounds isWide 
								ifTrue: [self upArrow8Bit rotateBy: #left centerAt: 0 @ 0]
								ifFalse: [self upArrow8Bit]])).
	self roundedScrollbarLook 
		ifTrue: 
			[upButton color: Color veryLightGray.
			upButton borderStyle: (BorderStyle complexRaised width: 3)]
		ifFalse: [upButton setBorderWidth: 1 borderColor: #raised].
	self addMorph: upButton