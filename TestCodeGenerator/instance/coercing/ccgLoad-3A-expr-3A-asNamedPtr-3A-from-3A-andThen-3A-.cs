ccgLoad: aBlock expr: exprString asNamedPtr: recordString from: anInteger andThen: valBlock
	"Answer codestring for integer pointer to first indexable field of object (without validating side-effect), as described in comment to ccgLoad:expr:asRawOopFrom:"

	^(valBlock value: anInteger), '.',
	 (aBlock value: (String streamContents: [:aStream | aStream
		nextPutAll: 'self cCoerce: (interpreterProxy firstIndexableField:';
		crtab: 4;
		nextPutAll: '(interpreterProxy stackValue:';
		nextPutAll: anInteger asString;
		nextPutAll:	'))';
		crtab: 3;
		nextPutAll: 'to: ''';
		nextPutAll: recordString;
		nextPutAll: ' *''']))