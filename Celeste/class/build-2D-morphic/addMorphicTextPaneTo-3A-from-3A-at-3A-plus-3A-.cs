addMorphicTextPaneTo: row from: views at: innerFractions plus: verticalOffset 
	row
		addMorph: (views at: #messageText)
		fullFrame: (LayoutFrame
				fractions: (innerFractions withBottom: 1)
				offsets: (0 @ verticalOffset corner: 0@0)).
	^ verticalOffset

