projectScreenMenu
	"Answer the project screen menu."

	^ SelectionMenu labelList:
		#(	'keep this menu up'

			'previous project'
			'jump to project...'
			'restore display'

			'open...'
			'windows...'
			'changes...'
			'help...'
			'appearance...'
			'do...'

			'save'
			'save as...'
			'save and quit'
			'quit')
		lines: #(1 4 10)
		selections: #(durableScreenMenu
returnToPreviousProject jumpToProject restoreDisplay
presentOpenMenu presentWindowMenu presentChangesMenu presentHelpMenu presentAppearanceMenu commonRequests
snapshot saveAs snapshotAndQuit quit )
"
ScreenController new projectScreenMenu startUp
"