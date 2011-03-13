unload
	(TheWorldMenu respondsTo: #registerOpenCommand:) ifTrue: 
		[TheWorldMenu unregisterOpenCommand: 'SqueakMap Package Loader'].
	self environment at: #Flaps ifPresent: [:cl |
	cl unregisterQuadsWithReceiver: self] 