testUpdate
	gofer load.
	self shouldnt: [ gofer update ] raise: Error.
	self assert: (self hasPackage: 'Bogus').
	self assert: (self hasPackage: 'BogusExt').
	self assert: (self hasPackage: 'BogusInfo')