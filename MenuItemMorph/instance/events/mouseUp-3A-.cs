mouseUp: evt
	"Handle a mouse up event. Menu items get activated when the mouse is over them."

	| mouseInMe |
	mouseInMe _ self containsPoint: evt cursorPoint.
	self deselectItem.
	self isInMenu
		ifTrue:
			[(mouseInMe and: [self selector = #toggleStayUp:])
				ifFalse: [owner deleteIfPopUpFrom: self event: evt].
			subMenu ifNil:
				[mouseInMe ifTrue:
					[evt hand world displayWorld.
					owner invokeItem: self event: evt]]]
		ifFalse:  
			[self invokeWithEvent: evt]
			
			
