forgetDispatchesTo: aSelector
	"aSelector is no longer implemented by my corresponding Player, so don't call it any more"
	mouseDownSelector == aSelector
		ifTrue:
			[mouseDownRecipient _ mouseDownSelector _ nil].
	mouseStillDownSelector == aSelector
		ifTrue:
			[mouseStillDownRecipient _ mouseStillDownSelector _ nil].
	mouseUpSelector == aSelector
		ifTrue:
			[mouseUpRecipient _ mouseUpSelector _ nil].
	mouseEnterSelector == aSelector
		ifTrue:
			[mouseEnterRecipient _ mouseEnterSelector _ nil].
	mouseLeaveSelector == aSelector
		ifTrue:
			[mouseLeaveRecipient _ mouseLeaveSelector _ nil].
	keyStrokeSelector == aSelector
		ifTrue:
			[keyStrokeRecipient _ keyStrokeSelector _ nil].