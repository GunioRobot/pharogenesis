addDismissHandle: handleSpec
	| dismissHandle |
	dismissHandle _ self addHandle: handleSpec
		on: #mouseDown send: #mouseDownInDimissHandle:with: to: self.
	dismissHandle on: #mouseUp send: #maybeDismiss:with: to: self.
	dismissHandle on: #mouseStillDown send: #setDismissColor:with: to: self.
