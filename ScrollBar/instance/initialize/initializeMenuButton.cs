initializeMenuButton
	menuButton := RectangleMorph
			newBounds: (self innerBounds topLeft extent: self buttonExtent)
			color: Color lightGray.
	menuButton on: #mouseEnter send: #menuButtonMouseEnter: to: self.
	menuButton on: #mouseDown send: #menuButtonMouseDown: to: self.
	menuButton on: #mouseLeave send: #menuButtonMouseLeave: to: self.
	menuButton addMorphCentered:
		(RectangleMorph newBounds: (0@0 extent: 4@2) color: Color black).
	menuButton setBorderWidth: 2 borderColor: #raised.
	self addMorph: menuButton