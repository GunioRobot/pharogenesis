mouseUp: evt
	"Handle a mouse up event. Menu items get activated when the mouse is over them."

	| mouseInMe w |
	self deselectItem.
	mouseInMe _ self bounds containsPoint: evt cursorPoint.
	self isInMenu ifTrue: [
		(mouseInMe and: [self selector = #toggleStayUp:]) ifFalse: [
			w _ owner world.
			owner deleteIfPopUp].
		subMenu ifNil: [
			mouseInMe ifTrue: [
				w ifNotNil: [w displayWorld].
				owner invokeItem: self]]].
