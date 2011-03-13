forgetDispatchesTo: aSelector
	"aSelector is no longer implemented by my corresponding Player, so don't call it any more"
	mouseDownSelector == aSelector
		ifTrue: [mouseDownRecipient := mouseDownSelector := nil].
	mouseMoveSelector == aSelector
		ifTrue: [mouseMoveRecipient := mouseMoveSelector := nil].
	mouseStillDownSelector == aSelector
		ifTrue: [mouseStillDownRecipient := mouseStillDownSelector := nil].
	mouseUpSelector == aSelector
		ifTrue: [mouseUpRecipient := mouseUpSelector := nil].
	mouseEnterSelector == aSelector
		ifTrue: [mouseEnterRecipient := mouseEnterSelector := nil].
	mouseLeaveSelector == aSelector
		ifTrue: [mouseLeaveRecipient := mouseLeaveSelector := nil].
	mouseEnterDraggingSelector == aSelector
		ifTrue: [mouseEnterDraggingRecipient := mouseEnterDraggingSelector := nil].
	mouseLeaveDraggingSelector == aSelector
		ifTrue: [mouseLeaveDraggingRecipient := mouseLeaveDraggingSelector := nil].
	clickSelector == aSelector
		ifTrue: [clickRecipient := clickSelector := nil].
	doubleClickSelector == aSelector
		ifTrue: [doubleClickRecipient := doubleClickSelector := nil].
	doubleClickTimeoutSelector == aSelector
		ifTrue: [doubleClickTimeoutRecipient := doubleClickTimeoutSelector := nil].
	keyStrokeSelector == aSelector
		ifTrue: [keyStrokeRecipient := keyStrokeSelector := nil].