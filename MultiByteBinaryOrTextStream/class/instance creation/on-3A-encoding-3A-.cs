on: aCollection encoding: encodingName 
	| aTextConverter |
	encodingName isNil
		ifTrue: [aTextConverter _ TextConverter default]
		ifFalse: [aTextConverter _ TextConverter newForEncoding: encodingName].
	^ (self on: aCollection)
		converter: aTextConverter