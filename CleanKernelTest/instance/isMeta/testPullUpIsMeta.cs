testPullUpIsMeta
	self
		deny: (self isSelector: #isMeta definedInClass: #ClassDescription).
	self
		deny: (self isSelector: #isMeta definedInClass: #Class).
	self
		assert: (self isSelector: #isMeta definedInClass: #Behavior)