addDragHandle: haloSpec
	(self addHandle: haloSpec on: #mouseDown send: #startDrag:with: to: self)
		on: #mouseStillDown send: #doDrag:with: to: self


