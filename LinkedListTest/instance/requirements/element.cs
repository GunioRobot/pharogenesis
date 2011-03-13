element
	^ link ifNil: [link := StackLink with: 42. "so that we can recognize this link"]