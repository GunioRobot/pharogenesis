printCategoryChunk: category on: aFileStream priorMethod: priorMethod
	"Print the message indicating that methods for the category follow 
	next on aFileStream.  If priorMethod is not nil, the message also
	indicates where to find the prior source code"

	aFileStream cr; command: 'H3'; nextPut: $!.
	aFileStream nextChunkPut: (String streamContents:
		[:strm |
		strm nextPutAll: self name;
			nextPutAll: ' methodsFor: ';
			print: category asString.
		priorMethod notNil ifTrue:
			[strm nextPutAll: ' priorSource: ';
				print: priorMethod filePosition;
				nextPutAll: ' inFile: ';
				print: priorMethod fileIndex]]).
	aFileStream command: '/H3'.