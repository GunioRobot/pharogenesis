simulateMouseEnter
	"Invoked from a client -- simulate mouseEnter"
	self lookEnable: #(overLook) disable:#(pressLook defaultLook).
	self executeSounds: #mouseEnter.
	self executeActions: #mouseEnter.