codeString
	| aStream |
	aStream _ ReadWriteStream on: ''.
	self storeCodeOn: aStream.
	^ aStream contents