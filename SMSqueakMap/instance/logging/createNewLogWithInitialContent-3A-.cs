createNewLogWithInitialContent: content
	"Create a new logfile. First chunk is current date.
	Fill it with optional content."

	| file directory |
	directory _ self directory.
	[file _ directory newFileNamed: (directory nextNameFor: 'squeakmap' extension: 'log').
	file nextChunkPut: Date today storeString.
	content ifNotNil: [file nextPutAll: content]]
		ensure: [file close]