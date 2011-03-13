fileOutMethod: selector
	"Write source code of a single method on a file.  Make up a name for the file."
	| fileStream |
	(self includesSelector: selector) ifFalse: [^ self].
	fileStream _ FileStream newFileNamed: 
		(self name , '-' , (selector copyReplaceAll: ':' with: '')) , '.st'.
	fileStream header; timeStamp.
	self printCategoryChunk: (self whichCategoryIncludesSelector: selector)
		on: fileStream.
	self printMethodChunk: selector
		on: fileStream
		moveSource: false
		toFile: 0.
	fileStream nextChunkPut: ' '; trailer; close