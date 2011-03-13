helpMenu
	"Answer the help menu to be put up as a screen submenu"

	HelpMenu == nil ifTrue:
		[HelpMenu _ SelectionMenu labelList:
		#(	'preferences...'
			'update code from server'
			'about this system...'
			'command-key help'
			'useful expressions'
			'set author initials...'
			'set desktop color...'
			'set display depth...'
			'full screen on'
			'full screen off'
			'view GIF imports'
			'space left'
			'vm statistics'
				)
		lines: #(2 5 8 10)
		selections: #(editPreferences  absorbUpdatesFromServer aboutThisSystem openCommandKeyHelp openStandardWorkspace setAuthorInitials setDesktopColor setDisplayDepth fullScreenOn fullScreenOff viewGIFImports garbageCollect vmStatistics)].
	^ HelpMenu

"
ScreenController new helpMenu startUp
ScreenController initialize
"