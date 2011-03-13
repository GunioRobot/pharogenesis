testLoad
	self shouldnt: [ gofer load ] raise: Error.
	self assert: (self hasPackage: 'Bogus'); assertClass: #BogusA.
	self assert: (self hasPackage: 'BogusExt'); assertClass: #BogusA selector: #isFake.
	self assert: (self hasPackage: 'BogusInfo'); assertClass: #BogusInfo