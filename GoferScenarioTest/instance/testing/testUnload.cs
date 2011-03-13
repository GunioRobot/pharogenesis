testUnload
	gofer load.
	self shouldnt: [ gofer unload ] raise: Error.
	self deny: (self hasPackage: 'Bogus').
	self deny: (self hasPackage: 'BogusExt').
	self deny: (self hasPackage: 'BogusInfo')