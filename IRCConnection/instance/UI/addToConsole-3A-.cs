addToConsole: aText
	"add aString to the text being displayed on console."
	consoleText _ consoleText, aText.
	consoleText size > 2000 ifTrue: [
		consoleText _ consoleText copyFrom: (consoleText size - 1000) to: consoleText size ].
	self changed: #consoleText.