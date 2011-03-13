testLike
	self assert: ((full like: 5) = 5).
	self assert: ((full like: 8) isNil).