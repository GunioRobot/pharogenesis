checkForDoubleClick: evt
	"Process the given mouse event to detect a click, double-click, or drag."

	| t tfmEvt nowPos dragClient dragStartEvent |
	tfmEvt _ evt transformedBy: eventTransform.
	t _ Time millisecondClockValue - firstClickTime.
	clickState = #firstClickDown ifTrue: [
		(((tfmEvt cursorPoint - firstClickEvent cursorPoint) r > 10)
			and: [clickClient containsPoint: firstClickEvent cursorPoint]) ifTrue:
			["consider it a drag if hand moves"
			"NOTE: First drag point must be from first click point,
			AND handPos must revert in case the target wants to be grabbed."
			nowPos _ self position.
			self position: firstClickEvent cursorPoint.
			dragClient _ clickClient.
			dragStartEvent _ firstClickEvent.
			self resetClickState.
			dragClient startDrag: dragStartEvent.
			self position: nowPos.
			^ self].
		tfmEvt isMouseUp ifTrue:
			[clickState _ #firstClickUp.
			^ self]].

	clickState = #firstClickUp ifTrue:
		[tfmEvt isMouseDown ifTrue:
			[clickClient doubleClick: firstClickEvent.
			^ self resetClickState].
		t > DoubleClickTime ifTrue:
			["clickClient click: firstClickEvent."
			^ self resetClickState]]