jumpIcon
	^ Preferences tinyDisplay
		ifTrue: [MenuIcons smallJumpIcon]
		ifFalse: [MenuIcons jumpIcon]