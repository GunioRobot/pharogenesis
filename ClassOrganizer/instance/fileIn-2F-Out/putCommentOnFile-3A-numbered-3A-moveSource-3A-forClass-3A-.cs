putCommentOnFile: aFileStream numbered: sourceIndex moveSource: moveSource forClass: aClass
	"Store the comment about the class onto file, aFileStream."
	| header |
	globalComment ifNotNil:
		[aFileStream cr; nextPut: $!.
		header _ String streamContents: [:strm | 
				strm nextPutAll: aClass name;
				nextPutAll: ' commentStamp: '.
				Utilities changeStamp storeOn: strm.
				strm nextPutAll: ' prior: '; nextPutAll: '0'].
		aFileStream nextChunkPut: header.
		aClass organization fileOutCommentOn: aFileStream
				moveSource: moveSource toFile: sourceIndex.
		aFileStream cr]