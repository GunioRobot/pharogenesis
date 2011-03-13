addServiceFor: aRequestor toMenu: aMenu
	aMenu
		add: self labelWithKeystroke
		target: self 
		selector: #executeFor:
		argument: aRequestor.
	aMenu lastItem isEnabled: self isEnabled.
	Preferences menuWithIcons & self icon notNil
		ifTrue: [aMenu lastItem icon: self icon].
	aMenu addBlankIconsIfNecessary: MenuIcons blankIcon.