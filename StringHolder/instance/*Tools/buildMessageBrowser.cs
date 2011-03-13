buildMessageBrowser
	"Create and schedule a message browser."

	self selectedMessageName ifNil: [^ self].
	Browser openMessageBrowserForClass: self selectedClassOrMetaClass 
		selector: self selectedMessageName editString: nil