projectScreenMenu
	"Answer the project screen menu.   7/23/96 sw
	 7/24/96 sw: remove misc menu thing"

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
			'quit...')
		lines: #(2 7)
		selections: #(exitProject restoreDisplay openMenu changesMenu windowMenu helpMenu commonRequests  snapshot saveAs quit)].
	^ ProjectScreenMenu

"
ScreenController new projectScreenMenu startUp
"