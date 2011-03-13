initializeMenuButton
"initialize the receiver's menuButton"
	"Preferences disable: #scrollBarsWithoutMenuButton"
	"Preferences enable: #scrollBarsWithoutMenuButton"
	(Preferences valueOfFlag: #scrollBarsWithoutMenuButton)
		ifTrue: [menuButton := nil .^ self].
	menuButton _ self roundedScrollbarLook
		ifTrue: [RectangleMorph
					newBounds: ((bounds isWide
							ifTrue: [upButton bounds topRight]
							ifFalse: [upButton bounds bottomLeft])
							extent: self buttonExtent)]
		ifFalse: [RectangleMorph
					newBounds: (self innerBounds topLeft extent: self buttonExtent)
					color: self thumbColor].
	menuButton
		on: #mouseEnter
		send: #menuButtonMouseEnter:
		to: self.
	menuButton
		on: #mouseDown
		send: #menuButtonMouseDown:
		to: self.
	menuButton
		on: #mouseLeave
		send: #menuButtonMouseLeave:
		to: self.
	"menuButton 
	addMorphCentered: (RectangleMorph 
	newBounds: (0 @ 0 extent: 4 @ 2) 
	color: Color black)."
	self updateMenuButtonImage.
	self roundedScrollbarLook
		ifTrue: [menuButton color: Color veryLightGray.
			menuButton
				borderStyle: (BorderStyle complexRaised width: 3)]
		ifFalse: [menuButton setBorderWidth: 1 borderColor: Color lightGray].
	self addMorph: menuButton