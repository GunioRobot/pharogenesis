simulateMouseLeave
	"Invoked from a client -- simulate mouse leave"
	self lookEnable: #(defaultLook) disable:#(pressLook overLook).
	self executeSounds: #mouseLeave.
	self executeActions: #mouseLeave.