openMenu
	"Answer a menu for open-related items.  
	 : useful expressions moved to help menu"

	OpenMenu == nil ifTrue:
		[OpenMenu _ SelectionMenu labelList:
		#(	'open browser'
			'open workspace'
			'open file list'
			'open change sorter'
			'open project'
			'open transcript'
			'open system workspace'
			'open Morphic world')
		lines: #()
		selections: #(openBrowser openWorkspace openFileList openChangeManager openProject openTranscript openSystemWorkspace openMorphicWorld)].
	^ OpenMenu
"
ScreenController new openMenu startUp
"