stickinessString
	^ self isSticky
		ifTrue: ['stop being sticky']
		ifFalse: ['start being sticky']
