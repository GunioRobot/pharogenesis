contents: c notifying: n
	| result |
	result _ super contents: c notifying: n.
	result == true ifTrue:
		[self initializeMessageList: Utilities recentlySubmittedMessages.
		self changed: #messageListChanged].
	^ result