helpMenu
	"Build the help menu for the world."
	| menu screenCtrl |
	screenCtrl _ ScreenController new.
	menu _ (MenuMorph entitled: 'help...') defaultTarget: self.
	menu addStayUpItem.
	menu add: 'about this system...' target: Smalltalk action: #aboutThisSystem.
	menu balloonTextForLastItem: 'current version information.'.
	menu add: 'update code from server' action: #absorbUpdatesFromServer.
	menu balloonTextForLastItem: 'load latest code updates via the internet'.
	menu add: 'preferences...' target: Preferences action: #openPreferencesInspector.
	menu balloonTextForLastItem: 'view and change various options.'.
	menu addLine.

	menu add: 'command-key help' target: Utilities action: #openCommandKeyHelp.
	menu balloonTextForLastItem: 'summary of keyboard shortcuts.'.
	menu add: 'world menu help' target: self action: #worldMenuHelp.
	menu balloonTextForLastItem: 'helps find menu items buried in submenus.'.
	"menu add: 'info about flaps' target: Utilities action: #explainFlaps."
	menu balloonTextForLastItem: 'describes how to enable and use flaps.'.

	menu add: 'font size summary' target: Utilities action: #fontSizeSummary.
	menu balloonTextForLastItem: 'summary of names and sizes of available fonts.'.

	menu add: 'useful expressions' target: Utilities action: #openStandardWorkspace.
	menu balloonTextForLastItem: 'a window full of useful expressions.'.

	menu add: 'graphical imports' target: Smalltalk action: #viewImageImports.
	menu balloonTextForLastItem: 'view the global repository called ImageImports; you can easily import external graphics into ImageImports via the FileList'.

	menu add: 'standard graphics library' target: ScriptingSystem action: #inspectFormDictionary.
	menu balloonTextForLastItem: 'lets you view and change the system''s standard library of graphics.'.

	menu addLine.

	menu addUpdating: #gridOnString action: #setGridding.
	menu balloonTextForLastItem: 'turn gridding on or off.'.
	menu add: 'set grid size...' action: #setGridSize.
	menu balloonTextForLastItem: 'specify the size of the grid.'.

	menu add: 'telemorphic...' action: #remoteDo.
	menu balloonTextForLastItem: 'commands for doing multi-machine "telemorphic" experiments'.
	menu addUpdating: #soundEnablingString target: Preferences action: #toggleSoundEnabling.
	menu balloonTextForLastItem: 'turning sound off will completely disable Squeak''s use of sound.'.
	menu add: 'definition for...' target: Utilities action: #lookUpDefinition.
	menu balloonTextForLastItem: 'if connected to the internet, use this to look up the definition of an English word.'.
	menu addLine.

	menu add: 'set author initials...' target: screenCtrl action: #setAuthorInitials.
	menu balloonTextForLastItem: 'supply initials to be used to identify the author of code and other content.'.
	menu add: 'vm statistics' target: screenCtrl action: #vmStatistics.
	menu balloonTextForLastItem: 'obtain some intriguing data about the vm.'.
	menu add: 'space left' target: screenCtrl action: #garbageCollect.
	menu balloonTextForLastItem: 'perform a full garbage-collection and report how many bytes of space remain in the image.'.
	^ menu
