printOn: aStream

	| aName |
	super printOn: aStream.

	(aName _ self knownName) ~~ nil ifTrue:
		[aStream nextPutAll: '<', aName, '>'].

	aStream nextPutAll: '('.
	aStream print: self identityHash;
			nextPutAll: ')'.