setCategory: newCategory 
	"Change the currently selected category. We must also compute the table  
	of contents and message list for the new category."

	| messageCount |
	currentCategory _ newCategory.
	newCategory isNil
		ifTrue: 
			[self status: nil.
			currentMessages _ currentTOC _ currentMsgID _ nil]
		ifFalse: 
			[currentMessages _ self filteredMessagesIn: newCategory.
			messageCount _ currentMessages size.
			messageCount > self maxMessageCount
				ifTrue: 
					[self messages: self maxMessageCount from: messageCount.
					currentMessages _ currentMessages copyLast: self maxMessageCount]
				ifFalse: [self messages: messageCount from: messageCount].
			self updateToc].
	self changed: #category.
	self changed: #tocEntryList.
	self changed: #tocEntry.
	self changed: #messageText