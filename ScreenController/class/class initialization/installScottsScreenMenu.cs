installScottsScreenMenu
	"Install the variant of the screen menu preferred by Scott.  To restore the standard version, just set the TopScreenMenu class variable back to nil, or call ScreenController revertToStandardMenus, which does just that. 7/24/96 sw"

	"ScreenController installScottsScreenMenu"
	TopScreenMenu _ SelectionMenu labelList:
		#('HyperSqueak...'
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
		lines: #(1 2 7)
		selections: #(hyperSqueakMenu restoreDisplay openMenu changesMenu windowMenu helpMenu commonRequests  snapshot saveAs snapshotAndQuit quit).

	ProjectScreenMenu _ SelectionMenu labelList:
		#('HyperSqueak...'
			'exit project'
			'restore display'
			'open...'
			'changes...'
			'window...'
			'help...'
			'do...'
			'save'
			'save as...'
			'quit...')
		lines: #(1 3 8)
		selections: #(hyperSqueakMenu exitProject restoreDisplay openMenu changesMenu windowMenu helpMenu commonRequests  snapshot saveAs quit)