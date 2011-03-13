topScreenMenu
	"Answer the screen menu for the top project, from whence there is no relevance to the 'exit project' item.  7/24/96 sw"

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
			'quit...')
		lines: #(1 6)
		selections: #( restoreDisplay openMenu changesMenu windowMenu helpMenu commonRequests  snapshot saveAs quit)].
	^ TopScreenMenu

"
ScreenController new newScreenMenu startUp
"