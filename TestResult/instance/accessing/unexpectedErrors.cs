unexpectedErrors
	^ errors select: [:each | each shouldPass] 