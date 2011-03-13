setWindow: aWindow 
	"Set the View's window to aWindow and unlock the View (see
	View|unlock). View|setWindow should be used by methods of View and
	subclasses to set the View window (rather than directly setting the
	instance variable) to insure that the View is unlocked."

	window := aWindow.
	viewport := nil.
	self unlock