testNoValueSupplier

	succeeded := eventSource 
		triggerEvent: #needsValue
		ifNotHandled: [true].
	self should: [succeeded]