ifOutPointer: anObject thenAllObjectsDo: aBlock
	| withSymbols segSize |
	"If I point out to anObject, bring me in, Submit all my objects to the block.  Write me out again."

	(state = #onFile or: [state = #onFileWithSymbols]) ifFalse: [^ self].
	withSymbols _ state = #onFileWithSymbols.
	(outPointers includes: anObject) ifFalse: [^ self].
	state = #onFile ifTrue: [Cursor read showWhile: [self readFromFile]].
	segSize _ segment size.
	self install.
	self allObjectsDo: [:obj | aBlock value: obj].	"do the work"
	self copyFromRoots: arrayOfRoots sizeHint: segSize.
	self extract.
	withSymbols 
		ifTrue: [self writeToFileWithSymbols]
		ifFalse: [self writeToFile].

