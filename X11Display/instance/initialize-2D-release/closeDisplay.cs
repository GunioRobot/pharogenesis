closeDisplay
	handle == nil ifFalse:[
		self XCloseDisplay: self.
		handle _ nil].