windowMenu
	"Answer a menu for windows-related items.  "

	^ SelectionMenu labelList:
		#(	'keep this menu up'

			'find window...'
			'find changed browsers...'
			'find changed windows...'

			'collapse all windows'
			'expand all windows'
			'close unchanged windows' ) , 
			(Array
				with: self bitCachingString
				with: self staggerPolicyString)
		lines: #(1 4 7)
		selections: #(durableWindowMenu
findWindow chooseDirtyBrowser chooseDirtyWindow
collapseAll expandAll closeUnchangedWindows
fastWindows changeWindowPolicy)
"
ScreenController new windowMenu startUp
"