fullPrintOn: aStream
	aStream print: self; cr.
	(self decompile ifNil: ['--source missing--']) fullPrintOn: aStream
