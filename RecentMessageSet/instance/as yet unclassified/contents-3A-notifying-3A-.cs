contents: c notifying: n
	| result |
	result _ super contents: c notifying: n.
	result == true ifTrue:
		[self initializeMessageList: Utilities recentlySubmittedMessages.
		self messageListIndex: (messageList size min: 1).	"0 or 1"
		self changed: #messageList.
		self changed: #messageListIndex].
	^ result