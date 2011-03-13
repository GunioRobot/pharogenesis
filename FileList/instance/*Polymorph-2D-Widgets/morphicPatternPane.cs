morphicPatternPane
	"Remove the vertical scrollbar since the minHeight would otherwise
	be too large to fit the layout frame. Added here for Pharo since
	FileList2 has been merged into FileList."
	
	|pane|
 	pane := PluggableTextMorph 
		on: self 
		text: #pattern 
		accept: #pattern:.
 	pane
		acceptOnCR: true;
		hideVScrollBarIndefinitely: true.
 	^pane