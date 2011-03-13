stringArrayEncoding
	^Array streamContents: [ :str |
		str
			nextPut: self name;
			nextPut: self version printString;
			nextPut: self description;
			nextPut: (self url ifNil: [ '(no download url)' ] ifNotNil: [ self url toText ]);
			nextPut: (self homepage ifNil: [ '' ] ifNotNil: [ self homepage toText ]);
			nextPut: self maintainer;
			nextPut: self provides size printString;
			nextPutAll: self provides;
			nextPut: self depends size printString;
			nextPutAll: self depends;
			nextPut: 0 printString;  "legacy conflicts field"
			nextPut: self category printString;
			nextPut: (self squeakMapID ifNil: [''] ifNotNil: [self squeakMapID asString])].