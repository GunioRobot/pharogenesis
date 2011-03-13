fileOutOn: aFileStream moveSource: moveSource toFile: fileIndex
	"File a description of the receiver on aFileStream. If the boolean 
	argument, moveSource, is true, then set the trailing bytes to the position 
	of aFileStream and to fileIndex in order to indicate where to find the 
	source code."
	aFileStream emphasis: 5.
	aFileStream nextChunkPut: self definition.
	aFileStream emphasis: 3.
	self organization
		putCommentOnFile: aFileStream
		numbered: fileIndex
		moveSource: moveSource.
	self organization categories do: 
		[:heading |
		self
			fileOutCategory: heading
			on: aFileStream
			moveSource: moveSource
			toFile: fileIndex]