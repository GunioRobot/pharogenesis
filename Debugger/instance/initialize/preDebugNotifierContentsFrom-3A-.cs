preDebugNotifierContentsFrom: messageString
	^ Preferences eToyFriendly
		ifFalse:
			[messageString]
		ifTrue:
			['An error has occurred; you should probably just hit ''abandon''.  Sorry!' translated] 