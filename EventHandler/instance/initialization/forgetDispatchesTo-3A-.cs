forgetDispatchesTo: aSelector
	"aSelector is no longer implemented by my corresponding Player, so don't call it any more"
	mouseDownSelector == aSelector
		ifTrue: [mouseDownRecipient _ mouseDownSelector _ nil].
	mouseMoveSelector == aSelector
		ifTrue: [mouseMoveRecipient _ mouseMoveSelector _ nil].
	mouseStillDownSelector == aSelector
		ifTrue: [mouseStillDownRecipient _ mouseStillDownSelector _ nil].
	mouseUpSelector == aSelector
		ifTrue: [mouseUpRecipient _ mouseUpSelector _ nil].
	mouseEnterSelector == aSelector
		ifTrue: [mouseEnterRecipient _ mouseEnterSelector _ nil].
	mouseLeaveSelector == aSelector
		ifTrue: [mouseLeaveRecipient _ mouseLeaveSelector _ nil].
	mouseEnterDraggingSelector == aSelector
		ifTrue: [mouseEnterDraggingRecipient _ mouseEnterDraggingSelector _ nil].
	mouseLeaveDraggingSelector == aSelector
		ifTrue: [mouseLeaveDraggingRecipient _ mouseLeaveDraggingSelector _ nil].
	clickSelector == aSelector
		ifTrue: [clickRecipient _ clickSelector _ nil].
	doubleClickSelector == aSelector
		ifTrue: [doubleClickRecipient _ doubleClickSelector _ nil].
	doubleClickTimeoutSelector == aSelector
		ifTrue: [doubleClickTimeoutRecipient _ doubleClickTimeoutSelector _ nil].
	keyStrokeSelector == aSelector
		ifTrue: [keyStrokeRecipient _ keyStrokeSelector _ nil].