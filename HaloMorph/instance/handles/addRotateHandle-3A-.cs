addRotateHandle: haloSpec
	(self addHandle: haloSpec on: #mouseDown send: #startRot:with: to: self)
		on: #mouseStillDown send: #doRot:with: to: self

