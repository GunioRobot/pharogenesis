initialize
	self becomeCompact.
	Smalltalk recreateSpecialObjectsArray.
	Smalltalk specialObjectsArray size = 41
		ifFalse: [self error: 'Please check size of special objects array!']