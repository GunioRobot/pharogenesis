preemptsMouseDown: evt
	"Handle mouse events even when the mouse is pressed over a mouse-sensitive object such a button."

	^ self handlesMouseDown: evt
