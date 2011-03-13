backIcon
	^ Preferences tinyDisplay
		ifTrue: [MenuIcons smallBackIcon]
		ifFalse: [MenuIcons backIcon]