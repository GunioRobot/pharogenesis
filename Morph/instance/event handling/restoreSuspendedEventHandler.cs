restoreSuspendedEventHandler
	| savedHandler |
	(savedHandler _ self valueOfProperty: #suspendedEventHandler) ifNotNil:
		[self eventHandler: savedHandler].
	submorphs do: [:m | m restoreSuspendedEventHandler]
