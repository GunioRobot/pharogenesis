addItemToMenu: aMenu
	aMenu
		add: self labelWithKeystroke
		target: self 
		selector: #trigger.
	Preferences menuWithIcons & self icon notNil
		ifTrue: [aMenu lastItem icon: self icon].
	aMenu addBlankIconsIfNecessary: MenuIcons blankIcon.