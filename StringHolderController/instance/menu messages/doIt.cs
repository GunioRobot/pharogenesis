doIt
	"Treat the current text selection as an expression; evaluate it.
	If the left shift key is down, wait for mouse click, then restore the display.
	 2/29/96 sw: if the selection is an insertion point, first select the current line."
	| result |
	self controlTerminate.
	result _ self evaluateSelection.
	self controlInitialize.
	^result