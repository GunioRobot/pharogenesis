fileOutOn: aFileStream moveSource: moveSource toFile: fileIndex
	super fileOutOn: aFileStream
		moveSource: moveSource
		toFile: fileIndex.
	(moveSource not and: [methodDict includesKey: #initialize]) ifTrue: 
		[aFileStream cr.
		aFileStream cr.
		aFileStream nextChunkPut: thisClass name , ' initialize'.
		aFileStream cr]