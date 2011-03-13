initializePagingArea
	"Initialize the receiver's pagingArea."
	
	pagingArea := RectangleMorph
				newBounds: self totalSliderArea
				color: (Color
						r: 0.6
						g: 0.6
						b: 0.8).
	pagingArea borderWidth: 0.
	pagingArea
		on: #mouseDown
		send: #scrollPageInit:
		to: self.
	pagingArea
		on: #mouseUp
		send: #finishedScrolling
		to: self.
	self addMorph: pagingArea.
	self roundedScrollbarLook
		ifTrue: [pagingArea
				color: (Color gray: 0.9)].
	Preferences gradientScrollbarLook ifFalse:[^self].
	pagingArea cornerStyle: (self theme scrollbarPagingAreaCornerStyleIn: self window).
	pagingArea on: #mouseUp send: #finishedScrolling: to: self.
	self on: #mouseEnter send: #mouseEnterPagingArea: to: self.
	self on: #mouseLeave send: #mouseLeavePagingArea: to: self