helpMenu
	"Answer the help menu to be put up as a screen submenu"

	HelpMenu == nil ifTrue:
		[HelpMenu _ SelectionMenu labelList:
		#(	'preferences...'
			'about this system...'
			'command-key help'
			'useful expressions'
			'set author initials...'
			'set desktop color...'
			'set display depth...'
			'view GIF imports'
			'space left'
			'vm statistics'
				)
		lines: #(1 4 7)
		selections: #(editPreferences  aboutThisSystem openCommandKeyHelp openStandardWorkspace setAuthorInitials setDesktopColor setDisplayDepth viewGIFImports garbageCollect vmStatistics)].
	^ HelpMenu

"
ScreenController new helpMenu startUp
ScreenController initialize
"