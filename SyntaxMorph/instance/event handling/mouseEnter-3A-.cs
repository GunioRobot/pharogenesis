mouseEnter: evt
	"Highlight this level as a potential grab target"

"Transcript cr; print: self; show: ' enter'."
	self unhighlightOwner.
	self highlightForGrab: evt.
	evt hand newKeyboardFocus: self.
