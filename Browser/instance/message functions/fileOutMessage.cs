fileOutMessage
	"Print a description of the selected message on the serial printer.
	4/11/96 tk - header, trailer"
	| fileStream |
	messageListIndex = 0 ifTrue: [^ self].
	fileStream _ FileStream newFileNamed: (self selectedClassOrMetaClass name , '-' , (self selectedMessageName copyReplaceAll: ':' with: '')) , '.st'.
	fileStream header; timeStamp.
	self selectedClassOrMetaClass printCategoryChunk: self selectedMessageCategoryName
		on: fileStream.
	self selectedClassOrMetaClass printMethodChunk: self selectedMessageName
		on: fileStream
		moveSource: false
		toFile: 0.
	fileStream nextChunkPut: ' '.
	fileStream trailer; close