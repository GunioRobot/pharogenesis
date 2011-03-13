projectScreenMenu
	"Answer the project screen menu."

	ProjectScreenMenu == nil ifTrue:
		[ProjectScreenMenu _ SelectionMenu labelList:
		#(	'previous project'
			'  jump to project...'
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
		lines: #(2 3 8)
		selections: #(returnToPreviousProject jumpToProject restoreDisplay openMenu changesMenu windowMenu helpMenu commonRequests  snapshot saveAs snapshotAndQuit quit)].
	^ ProjectScreenMenu

"
ScreenController new projectScreenMenu startUp
"