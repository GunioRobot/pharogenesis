printOn: aStream
	name isNil ifTrue: [^ super printOn: aStream].
	aStream nextPutAll: name.
	self stress > 0 ifTrue: [aStream print: self stress]