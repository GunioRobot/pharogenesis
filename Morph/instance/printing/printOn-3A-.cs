printOn: aStream

	| string aName |
	super printOn: aStream.

	(aName _ self knownName) ~~ nil ifTrue:
		[aStream nextPutAll: '<', aName, '>'].

	string _ self findA: StringMorph.
	aStream nextPutAll: '('.
	string ifNotNil: [
			aStream print: string contents; space]. 
	aStream print: self identityHash;
			nextPutAll: ')'.