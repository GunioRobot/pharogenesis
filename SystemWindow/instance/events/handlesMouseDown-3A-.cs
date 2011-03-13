handlesMouseDown: evt
	"If I am not the topWindow, then I will only respond to dragging by the title bar.
	Any other click will only bring me to the top"

	self flag: #bob.		"#handlesMouseDown: is in global coords, #mouseDown: is in local"
	(self fastFramingOn 
		and: [self labelRect containsPoint: (self globalPointToLocal: evt cursorPoint)])
		ifTrue: [^ true].
	^ self activeOnlyOnTop and: [self ~~ TopWindow]