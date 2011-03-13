helpMenu
	"Answer the help menu to be put up as a screen submenu.  7/24/96 sw"

	HelpMenu == nil ifTrue:
		[HelpMenu _ SelectionMenu labelList:
		#(	'preferences...'
			'about this system...'
			'command-key help'
			'useful expressions'
			'set author initials...'
			'view GIF imports'
			'space left'
				)
		lines: #(1 4)
		selections: #(editPreferences  aboutThisSystem openCommandKeyHelp openStandardWorkspace setAuthorInitials viewGIFImports garbageCollect)].
	^ HelpMenu

"
ScreenController new helpMenu startUp
ScreenController initialize
"