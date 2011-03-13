loadProjectIcon
	^ Preferences tinyDisplay
		ifTrue: [MenuIcons smallLoadProjectIcon]
		ifFalse: [MenuIcons loadProjectIcon]