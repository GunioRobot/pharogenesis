fromFileNamed: aFileName
	| file answer |
	file _ FileStream oldFileNamed: aFileName.
	answer _ self readFrom: file.
	file close.
	^ answer