updateListsAndCodeIn: aWindow
	self canDiscardEdits ifFalse: [^ self].
	Utilities mostRecentlySubmittedMessage = messageList first
		ifFalse:
			[self reformulateList]
		ifTrue:
			[self updateCodePaneIfNeeded]