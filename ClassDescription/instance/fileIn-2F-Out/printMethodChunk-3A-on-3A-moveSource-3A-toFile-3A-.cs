printMethodChunk: aSelector on: aFileStream moveSource: moveSource toFile: fileIndex
	"Print the source for the method of aSelector on aFileSteam, and move 
	the source to the source file specified by fileIndex if moveSource is true."
	| position method fastStream |
	aFileStream cr.
	moveSource ifTrue: [position _ aFileStream position].
	method _ self compiledMethodAt: aSelector.
	self copySourceCodeAt: aSelector to: aFileStream.
	moveSource ifTrue: [method setSourcePosition: position inFile: fileIndex]