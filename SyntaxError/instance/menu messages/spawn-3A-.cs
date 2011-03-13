spawn: aString 
	"Create and schedule a message browser on the message, aString. Any 
	edits already made are retained."

	self messageListIndex > 0
		ifTrue: 
			[^BrowserView
				openMessageBrowserForClass: class
				selector: selector
				editString: aString]