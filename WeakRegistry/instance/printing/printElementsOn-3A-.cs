printElementsOn: aStream
	aStream nextPut: $(.
	accessLock 
		ifNil: [self do: [:element | aStream print: element; space]]
		ifNotNil: [aStream nextPutAll: '<this WeakRegistry is locked>; space'].
	self isEmpty ifFalse: [aStream skip: -1].
	aStream nextPut: $)