addRecolorHandle: haloSpec
	innerTarget canSetColor ifTrue:
		[self addHandle: haloSpec on: #mouseUp send: #doRecolor:with:  to: self]


