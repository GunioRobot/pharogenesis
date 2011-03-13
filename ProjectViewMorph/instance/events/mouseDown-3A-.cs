mouseDown: evt

	"Smalltalk at: #Q put: OrderedCollection new"
	"Q add: {Time millisecondClockValue / 1000.0. self. evt hand mouseFocus. thisContext longStack}."

	evt hand newMouseFocus: self.
	self removeProperty: #wasOpenedAsSubproject.
	self showMouseState: 2.
	mouseDownTime _ Time millisecondClockValue