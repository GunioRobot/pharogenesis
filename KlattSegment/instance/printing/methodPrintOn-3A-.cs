methodPrintOn: aStream
	| param |
	aStream print: self name; cr;
		tab; nextPutAll: '^ self segmentFromArray: '; cr;
		tab; tab; nextPutAll: '"name	rank	duration	features"'; cr;
		tab; tab; nextPutAll: '#('; print: self name; tab; tab; print: self rank; tab; tab; print: self duration; tab; tab; tab; print: (self features ifNil: [#()]); cr;
		tab; tab; nextPutAll: '"selector		steady	fixed	prop	extern	intern"'.
	KlattFrame parameterNames do: [ :each |
		(param := self parameters at: (each, ':') asSymbol ifAbsent: [])
			ifNotNil: [aStream cr; tab; tab.
					param methodPrintOn: aStream]].
	aStream nextPut: $)