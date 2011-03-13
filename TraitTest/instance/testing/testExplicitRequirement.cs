testExplicitRequirement
	"self run: #testExplicitRequirement"

	self t1 compile: 'm self explicitRequirement'.
	self t2 compile: 'm ^true'.
	self assert: self t4 >> #m == (self t2 >> #m).
	self assert: self c2 new m.
	self t2 removeSelector: #m.
	self assert: self t5 >> #m == (self t1 >> #m).
	self should: [self c2 new m] raise: Error