removeMessageFromBrowser
	"Remove the selected message from the browser, but NOT from the system"
	self controlTerminate.
	(model respondsTo: #removeMessageFromBrowser) ifTrue: [model removeMessageFromBrowser].
	self controlInitialize