spawn: aString 
	"Create and schedule a message browser with the edited, but not yet 
	accepted, code (aString) displayed in the text view part of the browser."

	^self buildMessageBrowserEditString: aString