toggleStickiness
	extension == nil ifTrue: [^ self beSticky].
	extension sticky: extension sticky not