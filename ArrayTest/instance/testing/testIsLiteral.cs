testIsLiteral
	
	self assert: example1 isLiteral.
	example1 at: 1 put: self class.
	self deny: example1 isLiteral.
	example1 at: 1 put: 1.