beAllFont: aFont

	textStyle _ TextStyle fontArray: (Array with: aFont).
	self releaseCachedState; changed