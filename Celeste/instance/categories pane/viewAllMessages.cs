viewAllMessages
	currentMessages _ self filteredMessagesIn: self category.
	self messages: currentMessages size from:  currentMessages size .
	self updateToc.
	self changed: #tocEntryList.
	self changed: #tocEntry.
	self changed: #messageText.