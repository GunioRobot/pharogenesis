changeStyle
	"Let user change styles for the current text pane  
	 Moved from experimentalCommand to its own method  "

	| aList reply style |
	aList _ StrikeFont actualFamilyNames.
	aList addFirst: 'DefaultTextStyle'.
	reply _ (SelectionMenu labelList: aList lines: #(1) selections: aList) startUp.
	reply ifNotNil:
		[(style _ TextStyle named: reply) ifNil: [Beeper beep. ^ true].
		paragraph textStyle: style copy.
		paragraph composeAll.
		self recomputeSelection.
		self mvcRedisplay].
	^ true