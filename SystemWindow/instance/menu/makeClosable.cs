makeClosable
	mustNotClose _ false.
	closeBox ifNil:
		[self addCloseBox.
		self extent: self extent]