printAsLiteralFormOn: aStream
	aStream nextPut: $#.
	self printElementsOn: aStream
