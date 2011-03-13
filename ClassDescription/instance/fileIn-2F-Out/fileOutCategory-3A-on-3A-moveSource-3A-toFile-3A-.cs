fileOutCategory: aString on: aFileStream moveSource: moveSource toFile: fileIndex 
	"File a description of the receiver's category, aString, onto aFileStream. If 
	moveSource, is true, then set the method source pointer to the new file position.
	Note when this method is called with moveSource=true, it is condensing the
	.sources file, and should only write one preamble per method category."

	aFileStream cr.

true ifTrue:
	["Overridden to preserve author stamps in sources file regardless"
	(self organization listAtCategoryNamed: aString)
		do: [:sel | self printMethodChunk: sel withPreamble: true
						on: aFileStream moveSource: moveSource toFile: fileIndex].
	^ self].

	moveSource ifTrue:
		["Single header for condensing source files"
		self printCategoryChunk: aString on: aFileStream].
	(self organization listAtCategoryNamed: aString)
		do: [:sel | self printMethodChunk: sel withPreamble: moveSource not
						on: aFileStream moveSource: moveSource toFile: fileIndex].
	moveSource ifTrue: [aFileStream nextChunkPut: ' ']