buildMessageBrowserEditString: aString 
	"Create and schedule a message browser for the receiver in which the 
	argument, aString, contains characters to be edited in the text view."

	messageListIndex = 0 ifTrue: [^ self].
	^ self class openMessageBrowserForClass: self selectedClassOrMetaClass 
		selector: self selectedMessageName editString: aString