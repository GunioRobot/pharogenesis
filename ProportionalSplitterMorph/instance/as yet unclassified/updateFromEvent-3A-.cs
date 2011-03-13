updateFromEvent: anEvent 
	| delta firstRight firstBottom secondLeft secondTop selfTop selfBottom selfLeft selfRight |
	delta _ splitsTopAndBottom
				ifTrue: [0 @ ((self normalizedY: anEvent cursorPoint y) - lastMouse y)]
				ifFalse: [(self normalizedX: anEvent cursorPoint x) - lastMouse x @ 0].
				
	splitsTopAndBottom
		ifTrue: [lastMouse _ lastMouse x @ (self normalizedY: anEvent cursorPoint y)]
		ifFalse: [lastMouse _ (self normalizedX: anEvent cursorPoint x) @ lastMouse y].

	leftOrTop
				do: [:each | 
					firstRight _ each layoutFrame rightOffset
								ifNil: [0].
					firstBottom _ each layoutFrame bottomOffset
								ifNil: [0].
					each layoutFrame rightOffset: firstRight + delta x.
					each layoutFrame bottomOffset: firstBottom + delta y].
			rightOrBottom
				do: [:each | 
					secondLeft _ each layoutFrame leftOffset
								ifNil: [0].
					secondTop _ each layoutFrame topOffset
								ifNil: [0].
					each layoutFrame leftOffset: secondLeft + delta x.
					each layoutFrame topOffset: secondTop + delta y].
	selfTop _ self layoutFrame topOffset
				ifNil: [0].
	selfBottom _ self layoutFrame bottomOffset
				ifNil: [0].
	selfLeft _ self layoutFrame leftOffset
				ifNil: [0].
	selfRight _ self layoutFrame rightOffset
				ifNil: [0].
	self layoutFrame topOffset: selfTop + delta y.
	self layoutFrame bottomOffset: selfBottom + delta y.
	self layoutFrame leftOffset: selfLeft + delta x.
	self layoutFrame rightOffset: selfRight + delta x.
	self owner layoutChanged