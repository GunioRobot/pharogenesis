packages
	^ (self root collect: [:ea | ea package]) asSet asSortedCollection