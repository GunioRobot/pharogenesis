unexpectedFailures
	^ failures select: [:each | each shouldPass] 