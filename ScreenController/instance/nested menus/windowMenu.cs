windowMenu
	"Answer a menu for windows-related items.  2/4/96 sw"

	WindowMenu == nil ifTrue:
		[WindowMenu _ SelectionMenu labelList:
		#(	'find window...'
			'find changed windows...'
			'collapse all windows'
			'expand all windows'
			'close unchanged windows'
			'fast windows')
		lines: #(2 4)
		selections: #(findWindow indicateWindowsWithUnacceptedInput collapseAll expandAll  closeUnchangedWindows fastWindows)].
	^ WindowMenu

"
ScreenController new windowMenu startUp
"