unregister: aProviderClass
	(default = aProviderClass) ifTrue: [default _ nil].
	self registeredClasses remove: aProviderClass ifAbsent: [].