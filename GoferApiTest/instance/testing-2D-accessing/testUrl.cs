testUrl
	gofer url: 'http://source.lukas-renggli.ch/pier'.
	self assert: (gofer repository isKindOf: MCHttpRepository).
	self assert: (gofer repository locationWithTrailingSlash = 'http://source.lukas-renggli.ch/pier/').
	self assert: (gofer repository user isEmpty).
	self assert: (gofer repository password isEmpty)