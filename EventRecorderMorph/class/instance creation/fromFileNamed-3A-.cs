fromFileNamed: aFileName
	| file answer |
	file _ FileStream readOnlyFileNamed: aFileName.
	answer _ self readFrom: file setConverterForCode.
	file close.
	^ answer