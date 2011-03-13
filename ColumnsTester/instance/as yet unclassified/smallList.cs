smallList
	^ Array
		with: self mainList asOrderedCollection
		with: self secondList asOrderedCollection
		with: self minorList asOrderedCollection