onLeftMouseUp: event
	"The default response to left mouse up events"

	(event getCameraMorph) setEventFocus: nil.
	self respondWith: nil to: mouseMove.
