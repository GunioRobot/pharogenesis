mouseUp: evt
	self lookEnable:#(overLook) disable:#(pressLook).
	self executeSounds: #mouseUp.
	self executeActions: #mouseUp.