projectIcon
	^ Preferences tinyDisplay
		ifTrue: [MenuIcons smallProjectIcon]
		ifFalse: [MenuIcons projectIcon]