helpMenu 
	"Answer the help menu to be put up as a screen submenu"

	^ SelectionMenu labelList:
		#(	'keep this menu up'

			'about this system'
			'update code from server'
			'edit preferences...'

			'command-key help'
			'font size summary'
			'useful expressions'
			'view graphical imports'
			'standard graphics library'),

			(Array with: (Preferences soundsEnabled
							ifFalse: ['turn sound on']
							ifTrue: ['turn sound off'])) ,

		#(	'definition for...'
			'set author initials...'
			'vm statistics'
			'space left')
		lines: #(1 4 6 11)
		selections: #(durableHelpMenu aboutThisSystem absorbUpdatesFromServer
editPreferences  openCommandKeyHelp fontSizeSummary openStandardWorkspace viewImageImports
standardGraphicsLibrary soundOnOrOff  lookUpDefinition setAuthorInitials vmStatistics garbageCollect)
"
ScreenController new helpMenu startUp
"