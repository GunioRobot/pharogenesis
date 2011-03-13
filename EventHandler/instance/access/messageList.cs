messageList
	"Return a list of 'Class selector' for each message I can send.  tk
9/13/97"

	| list |
	list _ SortedCollection new.
	mouseDownRecipient ifNotNil:
		[list add: (mouseDownRecipient class classThatUnderstands:
					mouseDownSelector) name , ' ', mouseDownSelector].
	mouseMoveRecipient ifNotNil:
		[list add: (mouseMoveRecipient class classThatUnderstands:
					mouseMoveSelector) name , ' ', mouseMoveSelector].
	mouseStillDownRecipient ifNotNil:
		[list add: (mouseStillDownRecipient class classThatUnderstands:
					mouseStillDownSelector) name , ' ', mouseStillDownSelector].
	mouseUpRecipient ifNotNil:
		[list add: (mouseUpRecipient class classThatUnderstands:
					mouseUpSelector) name , ' ', mouseUpSelector].
	mouseEnterRecipient ifNotNil:
		[list add: (mouseEnterRecipient class classThatUnderstands:
					mouseEnterSelector) name , ' ', mouseEnterSelector].
	mouseLeaveRecipient ifNotNil:
		[list add: (mouseLeaveRecipient class classThatUnderstands:
					mouseLeaveSelector) name , ' ', mouseLeaveSelector].
	mouseEnterDraggingRecipient ifNotNil:
		[list add: (mouseEnterDraggingRecipient class classThatUnderstands:
					mouseEnterDraggingSelector) name , ' ', mouseEnterDraggingSelector].
	mouseLeaveDraggingRecipient ifNotNil:
		[list add: (mouseLeaveDraggingRecipient class classThatUnderstands:
					mouseLeaveDraggingSelector) name , ' ', mouseLeaveDraggingSelector].
	doubleClickRecipient ifNotNil:
		[list add: (doubleClickRecipient class classThatUnderstands:
					doubleClickSelector) name , ' ', doubleClickSelector].
	keyStrokeRecipient ifNotNil:
		[list add: (keyStrokeRecipient class classThatUnderstands:
					keyStrokeSelector) name , ' ', keyStrokeSelector].
	^ list