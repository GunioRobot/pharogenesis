toggleRoundness
	| sm w |
	w _ self world.
	self isRound
		ifTrue: [owner delete.
				w addMorph: self]
		ifFalse: [sm _ ScreeningMorph new position: self position.
				sm addMorph: self.
				sm addMorph: (EllipseMorph newBounds: self bounds).
				w addMorph: sm]