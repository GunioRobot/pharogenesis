forwardIcon
	^ Preferences tinyDisplay
		ifTrue: [MenuIcons smallForwardIcon]
		ifFalse: [MenuIcons forwardIcon]