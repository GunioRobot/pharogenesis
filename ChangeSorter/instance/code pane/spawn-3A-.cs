spawn: aString 
	"Create and schedule a message browser for the receiver in which the 
	argument, aString, contains characters to be edited in the text view."

	messageList listIndex = 0 ifTrue: [^ self].
	^ BrowserView
		openMessageBrowserForClass: self selectedClassOrMetaClass
		selector: self selectedMessageName
		editString: aString