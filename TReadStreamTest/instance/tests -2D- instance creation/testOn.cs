testOn
	self shouldnt: [self streamOn: '  '] raise: Error.
	self assert: (self streamOn: '  ') position isZero.