test0FixtureRequirementsOfTAddTest
	self 
		shouldnt: [ self collectionWithElement ]
		raise: Exception.
	self 
		shouldnt: [ self otherCollection ]
		raise: Exception.
	self 
		shouldnt: [ self element ]
		raise: Exception.
	self assert: (self collectionWithElement includes: self element).
	self deny: (self otherCollection includes: self element)