paintActor: anActor
	self world prepareToPaint: false.
	self mode: #paint.
	backup _ anActor getTexturePointer deepCopy.
	palette _ self world paintBox.
	palette position: self position + ((self extent x + 100) @ 0); focusMorph: self.