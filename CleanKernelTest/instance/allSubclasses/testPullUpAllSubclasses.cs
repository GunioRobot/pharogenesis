testPullUpAllSubclasses
	self
		deny: (self isSelector: #allSubclasses definedInClass: #ClassDescription).
	self
		assert: (self isSelector: #allSubclasses definedInClass: #Behavior)