addGrabHandle: haloSpec
	self addHandle: haloSpec on: #mouseDown send: #doGrab:with: to: self

