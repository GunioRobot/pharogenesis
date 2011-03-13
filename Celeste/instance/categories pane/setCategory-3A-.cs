setCategory: newCategory 
	"Change the currently selected category. We must also compute the table  
	of contents and message list for the new category."
	| messageCount |
	currentCategory _ newCategory.
	newCategory isNil
		ifTrue: [currentMessages _ currentTOC _ currentMsgID _ nil.
			self class includeStatusPane
				ifTrue: [status _ nil]]
		ifFalse: [currentMessages _ self filteredMessagesIn: newCategory.
			messageCount _ currentMessages size.
			messageCount > self maxMessagesToDisplay
				ifTrue: [self messages: self maxMessagesToDisplay from: messageCount.
				currentMessages _ currentMessages copyLast: self maxMessagesToDisplay]
				ifFalse: [self messages: messageCount from: messageCount].
			self cacheTOC].
	self changed: #category.
	self changed: #tocEntryList.
	self changed: #tocEntry.
	self changed: #messageText.
	self changed: #status