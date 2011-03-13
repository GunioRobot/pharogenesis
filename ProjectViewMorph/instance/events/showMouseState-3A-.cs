showMouseState: anInteger

	anInteger = 1 ifTrue: [		"enter"
		self addMouseActionIndicatorsWidth: 10 color: (Color blue alpha: 0.3).
		"self showBorderAs: Color blue"
	].

	anInteger = 2 ifTrue: [		"down"
		self addMouseActionIndicatorsWidth: 15 color: (Color blue alpha: 0.7).
		"self showBorderAs: Color red."
	].

	anInteger = 3 ifTrue: [		"leave"
		self deleteAnyMouseActionIndicators.
		"self showBorderAs: Color gray"
	].

