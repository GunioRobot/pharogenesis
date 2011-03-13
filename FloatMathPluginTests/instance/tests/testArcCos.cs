testArcCos
	| hash |
	hash := self runTest:[:f| self arcCos: f].
	self assert: hash = 175366936335278026567589867783483480383