getEventFocus
	"Return the actor that all events should go to. If not explicitly specified, choose the actor under the mouse cursor.  If no actor is under the mouse cursor, return nil.
	ar 6/2/1999: This method is more or less obsolete. For event handling, #convertEvent: should be used."
	self flag: #obsolete.

	eventFocus ifNotNil: [ ^ eventFocus ].

	^ myCamera pickAt: (Sensor cursorPoint).
