paintModeFor: anActor
	self mode: #paint.
	(self world paintBox) position: self position + (self extent x @ 0); focusMorph: self.