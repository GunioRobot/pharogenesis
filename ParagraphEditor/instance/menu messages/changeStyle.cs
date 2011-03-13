changeStyle
	"Let user change styles for the current text pane  
	 Moved from experimentalCommand to its own method  "

	| aList reply style |
	aList := StrikeFont actualFamilyNames.
	aList addFirst: 'DefaultTextStyle'.
	reply := UIManager default chooseFrom: aList values: aList lines: #(1).
	reply ifNotNil:
		[(style := TextStyle named: reply) ifNil: [Beeper beep. ^ true].
		paragraph textStyle: style copy.
		paragraph composeAll.
		self recomputeSelection.
		].
	^ true