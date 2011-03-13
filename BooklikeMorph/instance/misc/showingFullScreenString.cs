showingFullScreenString
	^ self isInFullScreenMode
		ifTrue:
			['exit full screen']
		ifFalse:
			['show full screen']