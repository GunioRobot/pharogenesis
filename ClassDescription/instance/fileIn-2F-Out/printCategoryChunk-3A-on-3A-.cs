printCategoryChunk: aString on: aFileStream
	"Print the message describing that methods for the category aString follow 
	next on aFileStream."

	aFileStream command: 'H3'.
	aFileStream cr; nextPut: $!.
	aFileStream nextChunkPut: (self name , ' methodsFor: ''' , aString , '''').
	aFileStream command: '/H3'.
