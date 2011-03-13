openIcon
	^ Preferences tinyDisplay
		ifTrue: [MenuIcons smallOpenIcon]
		ifFalse: [MenuIcons openIcon]