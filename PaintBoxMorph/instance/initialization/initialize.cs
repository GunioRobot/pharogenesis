initialize
	super initialize.
	self on: #mouseDown send: #yourself to: self.
	colorMemory ifNotNil: [colorMemory on: #mouseDown send: #takeColorEvt:from: to: self].