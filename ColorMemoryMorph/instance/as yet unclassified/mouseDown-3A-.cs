mouseDown: evt
	"If the shift key is pressed, make this string the keyboard input focus."

	self invalidRect: (self rectFromIndex: current).
	current _ self indexFromPoint: (evt cursorPoint - self topLeft).
	onVector at: current put: true.
	self invalidRect: (self rectFromIndex: current).
