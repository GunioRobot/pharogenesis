testUrlUsernamePassword
	gofer url: 'http://source.lukas-renggli.ch/pier' username: 'foo' password: 'bar'.
	self assert: (gofer repository isKindOf: MCHttpRepository).
	self assert: (gofer repository locationWithTrailingSlash = 'http://source.lukas-renggli.ch/pier/').
	self assert: (gofer repository user = 'foo').
	self assert: (gofer repository password = 'bar')