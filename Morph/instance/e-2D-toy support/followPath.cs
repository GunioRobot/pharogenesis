followPath
	| pathPoints offset |
	(pathPoints _ self renderedMorph valueOfProperty: #pathPoints) ifNil: [^ Beeper beep].
	offset _ owner position - (self extent // 2).
	pathPoints do:
		[:aPoint |
			self position: aPoint + offset.
			self world displayWorld.
			(Delay forMilliseconds: 20) wait]