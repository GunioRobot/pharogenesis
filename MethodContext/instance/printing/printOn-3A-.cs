printOn: aStream

	| h |
	self isExecutingBlock ifFalse: [^ super printOn: aStream].
	h _ self blockHome.
	h ifNil: [^ aStream nextPutAll: '[]'].
	aStream nextPutAll: '[] from '.
	h printOn: aStream