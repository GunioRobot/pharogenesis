simulateMouseDown
	"Invoked from a client --  simulate mouse down"
	self lookEnable: #(pressLook) disable:#(overLook).
	self executeSounds: #mouseDown.
	self executeActions: #mouseDown.