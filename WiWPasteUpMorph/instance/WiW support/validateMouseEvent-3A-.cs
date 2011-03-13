validateMouseEvent: evt

	evt isMouseDown ifFalse: [^ self].

	"any click outside returns us to our home world"
	(self bounds containsPoint: evt cursorPoint) ifFalse: [
		self revertToParentWorldWithEvent: evt.
	].