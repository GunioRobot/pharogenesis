addToConsole: aText
	consoleText _ consoleText, aText.
	consoleText size > 1000 ifTrue: [
		consoleText _ consoleText copyFrom: (consoleText size - 500) to: consoleText size ].
	self changed: #consoleText.