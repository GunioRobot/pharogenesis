testGemsource
	gofer gemsource: 'Seaside29'.
	self assert: gofer repository locationWithTrailingSlash = 'http://seaside.gemstone.com/ss/Seaside29/'