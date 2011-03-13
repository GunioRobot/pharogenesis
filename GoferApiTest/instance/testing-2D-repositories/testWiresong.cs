testWiresong
	gofer wiresong: 'ob'.
	self assert: gofer repository locationWithTrailingSlash = 'http://source.wiresong.ca/ob/'