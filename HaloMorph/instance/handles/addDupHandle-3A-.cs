addDupHandle: haloSpec
	self addHandle: haloSpec on: #mouseDown send: #doDup:with: to: self

