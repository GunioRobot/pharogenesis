mouseDown: evt
	self lookEnable: #(pressLook) disable:#(overLook).
	self executeSounds: #mouseDown.
	self executeActions: #mouseDown.