example3	
	"Create a passive view of some text on the screen."
	| view |
	view:= self new model: 'this is a test of one line
and the second line' asDisplayText.
	view translateBy: 100@100.	
	view borderWidth: 2.
	view display.
	view release

	"DisplayTextView example3"