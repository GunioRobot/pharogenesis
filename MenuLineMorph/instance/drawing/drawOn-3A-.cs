drawOn: aCanvas
	| pref |
	aCanvas
		fillRectangle: (bounds topLeft corner: bounds rightCenter)
		color: ((pref _ Preferences menuColorFromWorld)
					ifTrue:
						[owner color darker]
					ifFalse:
						[Preferences menuLineUpperColor]).
	aCanvas
		fillRectangle: (bounds leftCenter corner: bounds bottomRight)
		color: (pref
					ifTrue:
						[owner color lighter]
					ifFalse:
						[Preferences menuLineLowerColor])