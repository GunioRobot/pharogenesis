openMenu
	^ SelectionMenu labelList:
		#(	'keep this menu up'

			'browser'
			'package browser'
			'method finder'
			'workspace'
			'file list'
			'file...'
			'transcript'
			'morphic world'

			'simple change sorter'
			'dual change sorter'

			'mvc project'
			'morphic project'
			)
		lines: #(1 9 11)
		selections: #(durableOpenMenu
openBrowser openPackageBrowser openSelectorBrowser openWorkspace openFileList openFile openTranscript openMorphicWorld
openSimpleChangeSorter openChangeManager
openProject  openMorphicProject  )
"
ScreenController  new openMenu startUp
"