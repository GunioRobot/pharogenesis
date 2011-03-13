testSqueaksource
	gofer squeaksource: 'Seaside29'.
	self assert: gofer repository locationWithTrailingSlash = 'http://www.squeaksource.com/Seaside29/'