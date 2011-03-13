objectsIcon
	^ Preferences tinyDisplay
		ifTrue: [MenuIcons smallObjectsIcon]
		ifFalse: [MenuIcons objectsIcon]