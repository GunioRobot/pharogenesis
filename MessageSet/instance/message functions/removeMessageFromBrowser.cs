removeMessageFromBrowser
	"Remove the selected message from the browser."
	messageListIndex = 0 ifTrue: [^ self].
	self initializeMessageList: (messageList copyWithout: self selection).
	"self messageListIndex: 0."
	self changed: #messageList.
	self changed: #messageListIndex.
	self changed: #contents.
