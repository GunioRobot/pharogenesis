printMethodChunk: selector withPreamble: doPreamble on: outStream
		moveSource: moveSource toFile: fileIndex
	"Copy the source code for the method associated with selector onto the fileStream.  If moveSource true, then also set the source code pointer of the method."
	| preamble method oldPos newPos sourceFile endPos |
	doPreamble 
		ifTrue: [preamble _ self name , ' methodsFor: ' ,
					(self organization categoryOfElement: selector) asString printString]
		ifFalse: [preamble _ ''].
	method _ self methodDict at: selector ifAbsent:
		[outStream nextPutAll: selector; cr.
		outStream tab; nextPutAll: '** ERROR!  THIS SCRIPT IS MISSING ** ' translated; cr; cr.
		outStream nextPutAll: '  '.
		^ outStream].

	((method fileIndex = 0
		or: [(SourceFiles at: method fileIndex) == nil])
		or: [(oldPos _ method filePosition) = 0])
		ifTrue:
		["The source code is not accessible.  We must decompile..."
		preamble size > 0 ifTrue: [outStream cr; nextPut: $!; nextChunkPut: preamble; cr].
		outStream nextChunkPut: (self decompilerClass new decompile: selector
											in: self method: method) decompileString]
		ifFalse:
		[sourceFile _ SourceFiles at: method fileIndex.
		preamble size > 0
			ifTrue:    "Copy the preamble"
				[outStream copyPreamble: preamble from: sourceFile at: oldPos]
			ifFalse:
				[sourceFile position: oldPos].
		"Copy the method chunk"
		newPos _ outStream position.
		outStream copyMethodChunkFrom: sourceFile.
		sourceFile skipSeparators.      "The following chunk may have ]style["
		sourceFile peek == $] ifTrue: [
			outStream cr; copyMethodChunkFrom: sourceFile].
		moveSource ifTrue:    "Set the new method source pointer"
			[endPos _ outStream position.
			method checkOKToAdd: endPos - newPos at: newPos.
			method setSourcePosition: newPos inFile: fileIndex]].
	preamble size > 0 ifTrue: [outStream nextChunkPut: ' '].
	^ outStream cr