pastEndPut: anObject
	collection _ collection ,
		(collection class new: ((collection size max: 20) min: 20000)).
	writeLimit _ collection size.
	collection at: (position _ position + 1) put: anObject