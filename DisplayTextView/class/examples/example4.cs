example4	
	"Create four passive views of some text on the screen with fat borders."
	| view |
	view:= self new model: 'this is a test of one line
and the second line' asDisplayText.
	view translateBy: 100@100.	
	view borderWidth: 5.
	view display.
	3 timesRepeat: [view translateBy: 100@100. view display].
	view release

	"DisplayTextView example4"