initialize
	"initialize the state of the receiver"
	super initialize.
	""
	
	start _ 0.
	stop _ 100.
	minorTick _ 1.
	majorTick _ 10.
	minorTickLength _ 3.
	majorTickLength _ 10.
	caption _ nil.
	tickPrintBlock _ [:v | v printString].
	labelsAbove _ true.
	captionAbove _ true