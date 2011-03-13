windowMenu
	"Answer a menu for windows-related items.  "

	^ SelectionMenu labelList:
		#(	'find window...'
			'find changed browsers...'
			'find changed windows...'
			'collapse all windows'
			'expand all windows'
			'close unchanged windows') ,
			(Array with: (StandardSystemView cachingBits
							ifTrue: ['dont save bits (compact)']
							ifFalse: ['save bits (fast)'])
				with: ((Preferences valueOfFlag: #reverseWindowStagger)
							ifTrue: ['tile windows']
							ifFalse: ['stagger windows']))
		lines: #(3 5 6)
		selections: #(findWindow chooseDirtyBrowser chooseDirtyWindow
				collapseAll expandAll
				closeUnchangedWindows
				fastWindows changeWindowPolicy)

"
ScreenController new windowMenu startUp
ScreenController initialize
"