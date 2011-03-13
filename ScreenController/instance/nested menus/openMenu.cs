openMenu
	"ScreenController initialize"

	OpenMenu == nil ifTrue:
		[OpenMenu _ SelectionMenu labelList:
		#(	'open browser'
			'open workspace'
			'open file list'
			'open change sorter'
			'open project (mvc)'
			'open project (morphic)'
			'open transcript'
			'open Morphic world'
			'open Morphic construction')
		lines: #(7)
		selections: #(openBrowser openWorkspace openFileList openChangeManager openProject  openMorphicProject openTranscript  openMorphicWorld openMorphicConstructionWorld)].
	^ OpenMenu

"
ScreenController new openMenu startUp
"