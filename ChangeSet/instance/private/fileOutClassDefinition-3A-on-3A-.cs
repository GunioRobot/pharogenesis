fileOutClassDefinition: class on: stream 
	"Write out class definition for the given class on the given stream, if the class definition was added or changed."

	(self atClass: class includes: #rename) ifTrue:
		[stream nextChunkPut: 'Smalltalk renameClassNamed: #', (self oldNameFor: class), ' as: #', class name; cr].

	((self atClass: class includes: #change) or: [self atClass: class includes: #add]) ifTrue:
		[stream command: 'H3'; nextChunkPut: (self fatDefForClass: class); cr; command: '/H3'].

	(self atClass: class includes: #comment) ifTrue:
		[class theNonMetaClass organization putCommentOnFile: stream numbered: 0 moveSource: false forClass: class theNonMetaClass].

