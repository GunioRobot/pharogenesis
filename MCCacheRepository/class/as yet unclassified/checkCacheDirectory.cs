checkCacheDirectory
	default notNil and: [default directory exists ifFalse: [default _ nil]]