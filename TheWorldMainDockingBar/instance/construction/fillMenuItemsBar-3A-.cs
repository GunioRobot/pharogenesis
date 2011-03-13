fillMenuItemsBar: aDockingBar 
	"Private - fill the given docking bar"
	
	| squeakIcon homeIcon configurationIcon helpIcon squeakLabel projectLabel configurationLabel helpLabel |
	(aDockingBar isDockingBar not
			or: [Preferences tinyDisplay])
		ifTrue: [""
			squeakIcon := MenuIcons smallSqueakIcon.
			homeIcon := MenuIcons smallHomeIcon.
			configurationIcon := MenuIcons smallConfigurationIcon.
			helpIcon := MenuIcons smallHelpIcon]
		ifFalse: [""
			squeakIcon := MenuIcons squeakIcon.
			homeIcon := MenuIcons homeIcon.
			configurationIcon := MenuIcons configurationIcon.
			helpIcon := MenuIcons helpIcon].
	""
	Preferences tinyDisplay
		ifTrue: [""
			squeakLabel := '' .
			projectLabel := '' .
			configurationLabel := '' .
			helpLabel := '' ]
		ifFalse: [""
			squeakLabel := 'Squeak' translated.
			projectLabel := 'Project' translated.
			configurationLabel := 'Configuration' translated.
			helpLabel := 'Help' translated].
	""
	aDockingBar
		add: squeakLabel
		icon: squeakIcon
		help: 'Options related to Squeak as a whole' translated
		subMenu: self squeakMenu.
	aDockingBar
		add: projectLabel
		icon: homeIcon
		help: 'Options to open things in the current project or to navigate between projects' translated
		subMenu: self projectMenu.
	aDockingBar
		add: configurationLabel
		icon: configurationIcon
		help: 'Options to configure Squeak' translated
		subMenu: self configurationMenu.
	aDockingBar
		add: helpLabel
		icon: helpIcon
		help: 'Helpful options or options to get help' translated
		subMenu: self helpMenu