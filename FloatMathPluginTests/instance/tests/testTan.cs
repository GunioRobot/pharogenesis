testTan
	| hash |
	hash := self runTest:[:f| self tan: f].
	self assert: hash = 169918898922109300293069449425089094780