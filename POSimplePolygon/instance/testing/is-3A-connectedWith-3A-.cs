is: first connectedWith: second 
	^ (self after: first)
		= second or: [self before: first = second]