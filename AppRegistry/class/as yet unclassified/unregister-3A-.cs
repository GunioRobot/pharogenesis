unregister: aProviderClass
	(default = aProviderClass) ifTrue: [default := nil].
	self registeredClasses remove: aProviderClass ifAbsent: [].