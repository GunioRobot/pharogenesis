dispose
	handle == nil ifFalse:[
		self apiDisposePixPat: self.
		handle _ nil.
	].