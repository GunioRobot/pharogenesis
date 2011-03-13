browseReference: ref
	self okToChange ifTrue: [
	self initializeMessageList: (OrderedCollection with: ref).
	self changed: #messageList.
	self messageListIndex: 1.
	] 