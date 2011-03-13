configurationMenu
	| menu |
	menu := MenuMorph new defaultTarget: self.
	""
	self createMenuItem: {'set language...'. 'Choose the language in which Squeak should be displayed'. MenuIcons smallLanguageIcon} on: menu.
	menu addLine.
	self createMenuItem: {'update from server'. 'Update from server (Internet access is required)'. MenuIcons smallUpdateIcon} on: menu.
	""
	menu addLine.
	menu addUpdating: #showWorldMainDockingBarString action: #toggleShowWorldMainDockingBar.
	Flaps sharedFlapsAllowed
		ifTrue: [menu
				addUpdating: #suppressFlapsString
				target: Project current
				action: #currentToggleFlapsSuppressed].
	menu addLine.
	self createMenuItem: {'set world color...'. 'Choose a color to use as world background.'} on: menu.
	Display isFullScreen
		ifTrue: [self createMenuItem: {'exit from full screen'. 'Exit from full screen and enclose Squeak in a window'. MenuIcons smallFullScreenIcon} on: menu]
		ifFalse: [self createMenuItem: {'switch to full screen'. 'Switch to full screen giving the maximun display space to Squeak'. MenuIcons smallFullScreenIcon} on: menu].
	""
	self createMenuItem: {'change sound volume'. 'Change sound volume'. MenuIcons smallVolumeIcon} on: menu.
	menu addLine.
	Preferences useUndo
				ifTrue: [""
					self createMenuItem: {'purge undo records'. 'Save space by removing all the undo information.'} on: menu.
					menu addLine].
			self createMenuItem: {'preferences..'. 'Opens a "Preferences Panel" which allows you to alter many settings'. MenuIcons smallConfigurationIcon} on: menu.
			self createMenuItem: {'appearance...'. nil. MenuIcons smallConfigurationIcon} on: menu.
	self createMenuItem: {'set color theme...'. 'Choose the color theme in which Squeak should be displayed'} on: menu.
	menu addLine.
	^ menu