changeStyle
	"Let user change styles for the current text pane  
	 Moved from experimentalCommand to its own method  "

	| aList reply style |
	aList _ (TextConstants select: [:thang | thang isKindOf: TextStyle])
			keys asOrderedCollection.
	reply _ (SelectionMenu labelList: aList selections: aList) startUp.
	reply ~~ nil ifTrue:
		[(style _ TextStyle named: reply) ifNil: [self beep. ^ true].
		paragraph textStyle: style copy.
		paragraph composeAll.
		self recomputeSelection.
		self mvcRedisplay].
	^ true