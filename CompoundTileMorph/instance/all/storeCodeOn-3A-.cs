storeCodeOn: aStream

	aStream nextPut: $(.
	testPart storeCodeOn: aStream.
	aStream nextPut: $); cr; tab; nextPutAll: 'ifTrue: ['; cr.
	self storeCodeBlockFor: yesPart on: aStream.
	aStream nextPut: $]; cr; tab; nextPutAll: 'ifFalse: ['; cr.
	self storeCodeBlockFor: noPart on: aStream.
	aStream nextPut: $]; cr.
