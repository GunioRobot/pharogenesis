on: eventName send: selector to: recipient
	eventName == #mouseDown ifTrue:
		[mouseDownRecipient _ recipient.  mouseDownSelector _ selector. ^ self].
	eventName == #mouseMove ifTrue:
		[mouseMoveRecipient _ recipient.  mouseMoveSelector _ selector. ^ self].
	eventName == #mouseStillDown ifTrue:
		[mouseStillDownRecipient _ recipient.  mouseStillDownSelector _ selector. ^ self].
	eventName == #mouseUp ifTrue:
		[mouseUpRecipient _ recipient.  mouseUpSelector _ selector. ^ self].
	eventName == #mouseEnter ifTrue:
		[mouseEnterRecipient _ recipient.  mouseEnterSelector _ selector. ^ self].
	eventName == #mouseLeave ifTrue:
		[mouseLeaveRecipient _ recipient.  mouseLeaveSelector _ selector. ^ self].
	eventName == #mouseEnterDragging ifTrue:
		[mouseEnterDraggingRecipient _ recipient.  mouseEnterDraggingSelector _ selector. ^ self].
	eventName == #mouseLeaveDragging ifTrue:
		[mouseLeaveDraggingRecipient _ recipient.  mouseLeaveDraggingSelector _ selector. ^ self].
	eventName == #click ifTrue:
		[clickRecipient _ recipient. clickSelector _ selector. ^ self].
	eventName == #doubleClick ifTrue:
		[doubleClickRecipient _ recipient. doubleClickSelector _ selector. ^ self].
	eventName == #doubleClickTimeout ifTrue:
		[doubleClickTimeoutRecipient _ recipient. doubleClickTimeoutSelector _ selector. ^ self].
	eventName == #startDrag ifTrue:
		[startDragRecipient _ recipient. startDragSelector _ selector. ^ self].
	eventName == #keyStroke ifTrue:
		[keyStrokeRecipient _ recipient.  keyStrokeSelector _ selector. ^ self].
	eventName == #gesture ifTrue:
		[ ^self onGestureSend: selector to: recipient ].
	self error: 'Event name, ' , eventName , ' is not recognizable.'
