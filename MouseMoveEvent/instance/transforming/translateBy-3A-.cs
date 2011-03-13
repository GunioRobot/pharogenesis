translateBy: delta
	"add delta to cursorPoint, and return the new event"
	position _ position + delta.
	startPoint _ startPoint + delta.