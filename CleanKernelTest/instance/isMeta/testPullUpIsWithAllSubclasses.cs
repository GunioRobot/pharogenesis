testPullUpIsWithAllSubclasses
	"self run: #testPullUpIsWithAllSubclasses" 
	self
		deny: (self isSelector: #withAllSubclasses definedInClass: #ClassDescription).
	self
		assert: (self isSelector: #withAllSubclasses definedInClass: #Behavior)