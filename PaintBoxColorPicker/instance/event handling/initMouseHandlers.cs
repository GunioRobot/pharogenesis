initMouseHandlers

	self on: #mouseDown send: #startColorSelection: to: self.
	self on: #mouseStillDown send: #selectColor: to: self.
	self on: #mouseUp send: #endColorSelection: to: self.
	self on: #mouseLeave send: #delete to: self.
