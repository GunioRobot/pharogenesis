buildMessageBrowser
	"Create and schedule a message browser on the current method."

	contextStackIndex = 0 ifTrue: [^ self].
	^ Browser
		openMessageBrowserForClass: self selectedClassOrMetaClass
		selector: self selectedMessageName
		editString: nil