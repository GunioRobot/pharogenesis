pastEndPut: anObject
	collection size >= limit ifTrue: [limitBlock value].  "Exceptional return"
	collection _ collection ,
		(collection class new: ((collection size max: 20) min: limit)).
	writeLimit _ collection size.
	collection at: (position _ position + 1) put: anObject