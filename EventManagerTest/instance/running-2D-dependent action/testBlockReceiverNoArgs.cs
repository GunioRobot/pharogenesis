testBlockReceiverNoArgs
	eventSource when: #anEvent evaluate:[self heardEvent].
	eventSource triggerEvent: #anEvent.
	self should: [succeeded]