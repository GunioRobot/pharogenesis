checkForDoubleClick: evt
	"Process the given mouse event to detect a click, double-click, or drag."

	| t |
	t _ Time millisecondClockValue - firstClickTime.
	clickState = #firstClickDown ifTrue: [
		(t > DoubleClickTime or:
		 [(evt cursorPoint - firstClickEvent cursorPoint) r > 15]) ifTrue: [
			"consider it a drag if hand moves or timeout expires"
			clickClient drag: firstClickEvent.
			^ self resetClickState].
		evt isMouseUp ifTrue: [
			clickState _ #firstClickUp.
			^ self]].

	clickState = #firstClickUp ifTrue: [
		evt isMouseDown ifTrue: [
			clickClient doubleClick: firstClickEvent.
			^ self resetClickState].
		t > DoubleClickTime ifTrue: [
			clickClient click: firstClickEvent.
			^ self resetClickState]].
