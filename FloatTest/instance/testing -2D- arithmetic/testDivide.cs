testDivide
	self assert: 2.0 / 1 = 2.
	self should: [ 2.0 / 0 ] raise: ZeroDivide.