setDefaultParameters

	| worldColor |
	((Preferences menuColorFromWorld and: [Display depth > 4]) and: [(worldColor _ self currentWorld color) isColor])
		ifTrue: [self setColor: (worldColor luminance > 0.7
						ifTrue: [worldColor mixed: 0.8 with: Color black]
						ifFalse: [worldColor mixed: 0.4 with: Color white])
						"Think about whether alpha should be included."
					borderWidth: Preferences menuBorderWidth
					borderColor: #raised]
		ifFalse: [self setColor: Preferences menuColor
					borderWidth: Preferences menuBorderWidth
					borderColor: Preferences menuBorderColor].
	self layoutInset: 3.