projectScreenMenu
	"Answer the project screen menu.   
	 : remove misc menu thing"

	ProjectScreenMenu == nil ifTrue:
		[ProjectScreenMenu _ SelectionMenu labelList:
		#(	'exit project'
			'restore display'
			'open...'
			'changes...'
			'window...'
			'help...'
			'do...'
			'save'
			'save as...'
			'save and quit'
			'quit...')
		lines: #(2 7)
		selections: #(exitProject restoreDisplay openMenu changesMenu windowMenu helpMenu commonRequests  snapshot saveAs snapshotAndQuit quit)].
	^ ProjectScreenMenu

"
ScreenController new projectScreenMenu startUp
"