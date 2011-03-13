handlesMouseDown: evt
	"If I am not the topWindow, then my mouseDown action dominates"
	^ self activeOnlyOnTop and: [self ~~ TopWindow]