testIncludes
	self assert: (full includes: 5).
	self assert: (full includes: #abc).
	self deny: (full includes: 3).
			