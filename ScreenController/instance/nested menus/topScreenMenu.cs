topScreenMenu
	"Answer the screen menu for the top project, from whence there is no relevance to the 'exit project' item.  "

	TopScreenMenu == nil ifTrue:
		[TopScreenMenu _ SelectionMenu labelList:
		#(	'restore display'
			'open...'
			'changes...'
			'window...'
			'help...'
			'do...'
			'save'
			'save as...'
			'save and quit'
			'quit...')
		lines: #(1 6)
		selections: #( restoreDisplay openMenu changesMenu windowMenu helpMenu commonRequests  snapshot saveAs snapshotAndQuit quit)].
	^ TopScreenMenu

"
ScreenController new newScreenMenu startUp
"