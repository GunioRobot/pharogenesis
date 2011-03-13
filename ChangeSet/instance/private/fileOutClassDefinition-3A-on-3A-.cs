fileOutClassDefinition: class on: stream 
	"Write out class definition for the given class on the given stream, if the class definition was added or changed.  5/15/96 sw"

	((self atClass: class includes: #add) or: [self atClass: class includes: #change])
		ifTrue:
			[stream emphasis: 5; nextChunkPut: class definition; cr; emphasis: 1]