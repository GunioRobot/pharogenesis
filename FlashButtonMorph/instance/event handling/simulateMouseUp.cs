simulateMouseUp
	"Invoked from a client -- simulate mouse up"
	self lookEnable:#(overLook) disable:#(pressLook).
	self executeSounds: #mouseUp.
	self executeActions: #mouseUp.