on: eventName send: selector to: recipient
	eventName = #mouseDown ifTrue:
		[mouseDownRecipient _ recipient.  mouseDownSelector _ selector. ^ self].
	eventName = #mouseStillDown ifTrue:
		[mouseStillDownRecipient _ recipient.  mouseStillDownSelector _ selector. ^ self].
	eventName = #mouseUp ifTrue:
		[mouseUpRecipient _ recipient.  mouseUpSelector _ selector. ^ self].
	eventName = #mouseEnter ifTrue:
		[mouseEnterRecipient _ recipient.  mouseEnterSelector _ selector. ^ self].
	eventName = #mouseLeave ifTrue:
		[mouseLeaveRecipient _ recipient.  mouseLeaveSelector _ selector. ^ self].
	eventName = #keyStroke ifTrue:
		[keyStrokeRecipient _ recipient.  keyStrokeSelector _ selector. ^ self].
	self error: 'Event name, ' , eventName , ' is not recognizable.'
