initForEvents
	mouseOverHandler _ nil.
	lastMouseEvent _ MouseEvent new setType: #mouseMove position: 0@0 buttons: 0 hand: self.
	lastEventBuffer _ {1. 0. 0. 0. 0. 0. nil. nil}.
	self resetClickState.