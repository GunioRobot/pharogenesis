messageList
	"Return a list of 'Class selector' for each message I can send.  tk
9/13/97"

	| list |
	list _ SortedCollection new.
	mouseDownRecipient ifNotNil:
		[list add: (mouseDownRecipient class classThatUnderstands:
	mouseDownSelector) name,
			' ', mouseDownSelector].
	mouseStillDownRecipient ifNotNil:
		[list add: (mouseStillDownRecipient class classThatUnderstands:
	mouseStillDownSelector) name,
			' ', mouseStillDownSelector].
	mouseUpRecipient ifNotNil:
		[list add: (mouseUpRecipient class classThatUnderstands:
	mouseUpSelector) name,
			' ', mouseUpSelector].
	mouseEnterRecipient ifNotNil:
		[list add: (mouseEnterRecipient class classThatUnderstands:
	mouseEnterSelector) name,
			' ', mouseEnterSelector].
	mouseLeaveRecipient ifNotNil:
		[list add: (mouseLeaveRecipient class classThatUnderstands:
	mouseLeaveSelector) name,
			' ', mouseLeaveSelector].
	keyStrokeRecipient ifNotNil:
		[list add: (keyStrokeRecipient class classThatUnderstands:
	keyStrokeSelector) name,
			' ', keyStrokeSelector].
	^ list