restoreSuspendedEventHandler
	| savedHandler |
	(savedHandler _ self valueOfProperty: #suspendedEventHandler) ifNotNil:
		[self eventHandler: savedHandler]