initializeDownButton
	"initialize the receiver's downButton"

	downButton _ RectangleMorph 
				newBounds: (self innerBounds bottomRight - self buttonExtent 
						extent: self buttonExtent)
				color: self thumbColor.
	downButton 
		on: #mouseDown
		send: #scrollDownInit
		to: self.
	downButton 
		on: #mouseUp
		send: #finishedScrolling
		to: self.
	self updateDownButtonImage.
	self roundedScrollbarLook 
		ifTrue: 
			[downButton color: Color veryLightGray.
			downButton borderStyle: (BorderStyle complexRaised width: 3)]
		ifFalse: [downButton setBorderWidth: 1 borderColor: Color lightGray].
	self addMorph: downButton