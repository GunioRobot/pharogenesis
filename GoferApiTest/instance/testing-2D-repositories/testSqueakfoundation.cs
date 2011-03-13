testSqueakfoundation
	gofer squeakfoundation: '39a'.
	self assert: gofer repository locationWithTrailingSlash = 'http://source.squeakfoundation.org/39a/'