printOn: aStream 
	| name |
	(name := self name) ifNotNil: 
		[ ^ aStream
			nextPutAll: 'Color ';
			nextPutAll: name ].
	self storeOn: aStream