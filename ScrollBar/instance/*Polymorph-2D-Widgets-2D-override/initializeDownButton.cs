initializeDownButton
	"initialize the receiver's downButton"

	downButton := RectangleMorph 
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
		
	Preferences gradientScrollbarLook ifFalse:[^self addMorph: downButton].
	downButton cornerStyle: (self theme scrollbarButtonCornerStyleIn: self window).
	downButton on: #mouseUp send: #finishedScrolling: to: self.
	downButton on: #mouseEnter send: #mouseEnterDownButton: to: self.
	downButton on: #mouseLeave send: #mouseLeaveDownButton: to: self.
	self addMorph: downButton