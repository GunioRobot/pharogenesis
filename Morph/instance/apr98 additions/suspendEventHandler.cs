suspendEventHandler
	eventHandler ifNotNil:
		[self setProperty: #suspendedEventHandler toValue: eventHandler.
		eventHandler _ nil]