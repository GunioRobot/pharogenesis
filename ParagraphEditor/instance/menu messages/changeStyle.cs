changeStyle
	"Let user change styles for the current text pane  8/20/96 tk
	 Moved from experimentalCommand to its own method  8/20/96 sw"

	| aList reply style |
	aList _ (TextConstants at: #StyleNames).
	reply _ (SelectionMenu labelList: aList selections: aList) startUp.
	reply ~~ nil ifTrue:
		[style _ TextConstants at: reply ifAbsent: [self beep. ^ true].
		style class == TextStyle ifFalse: [self beep. ^ true].
		paragraph textStyle: style.
		paragraph composeAll.
		self recomputeSelection.
		Display fill: paragraph clippingRectangle 
			fillColor: view backgroundColor.	"very brute force"
		self display.
		"paragraph changed"].
	^ true