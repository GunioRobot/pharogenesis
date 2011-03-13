initializeOpenMenuForInternalUse
	"Resets the standard open menu to add internal items"
	"ScreenController initializeOpenMenuForInternalUse"

	OpenMenu _ SelectionMenu labelList:
		#(	'open browser'
			'open workspace'
			'open file list'
			'open change sorter'
			'open project (mvc)'
			'open project (morphic)'
			'open transcript'
			'open Morphic world'
			'open Morphic construction'
			'open etoy controls'
			'open blank etoy'
			'open Imagineering Studio')
		lines: #(7 9)
		selections: #(openBrowser openWorkspace openFileList openChangeManager openProject openMorphicProject openTranscript openMorphicWorld openMorphicConstructionWorld openEToyPanel openEToy openImagineeringStudio)