openMenu
	"Answer a menu for open-related items.  2/4/96 sw
	 5/10/96 sw: useful expressions moved to help menu"

	OpenMenu == nil ifTrue:
		[OpenMenu _ SelectionMenu labelList:
		#(	'open browser'
			'open workspace'
			'open file list'
			'open project'
			'open transcript'
			'open system workspace')
		selections: #(openBrowser openWorkspace openFileList openProject openTranscript  openSystemWorkspace)].
	^ OpenMenu

"
ScreenController new openMenu startUp
"