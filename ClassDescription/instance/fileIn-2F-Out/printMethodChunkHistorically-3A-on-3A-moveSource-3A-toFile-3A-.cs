printMethodChunkHistorically: selector on: outStream moveSource: moveSource toFile: fileIndex
	"Copy all source codes historically for the method associated with selector onto the 
	fileStream.  If moveSource true, then also set the source code pointer of the method."

	| preamble method newPos sourceFile endPos category changeList prior |
	category _ self organization categoryOfElement: selector.
	preamble _ self name , ' methodsFor: ', category asString printString.
	method _ self methodDict at: selector.
	((method fileIndex = 0
	or: [(SourceFiles at: method fileIndex) == nil])
	or: [method filePosition = 0])
	ifTrue: [
		outStream cr; nextPut: $!; nextChunkPut: preamble; cr.
		outStream nextChunkPut: method decompileString.
		outStream nextChunkPut: ' '; cr]
	ifFalse: [
		changeList _ ChangeSet 
			scanVersionsOf: method 
			class: self 
			meta: self isMeta
			category: category 
			selector: selector.
		newPos _ nil.
		sourceFile _ SourceFiles at: method fileIndex.
		changeList reverseDo: [ :chgRec |
			chgRec fileIndex = fileIndex ifTrue: [
				outStream copyPreamble: preamble from: sourceFile at: chgRec position.
				(prior _ chgRec prior) ifNotNil: [
					outStream position: outStream position - 2.
					outStream nextPutAll: ' prior: ', (
						prior first = method fileIndex ifFalse: [prior third] ifTrue: [
							SourceFiles 
								sourcePointerFromFileIndex: method fileIndex 
								andPosition: newPos]) printString.
					outStream nextPut: $!; cr].
				"Copy the method chunk"
				newPos _ outStream position.
				outStream copyMethodChunkFrom: sourceFile at: chgRec position.
				sourceFile skipSeparators.      "The following chunk may have ]style["
				sourceFile peek == $] ifTrue: [
					outStream cr; copyMethodChunkFrom: sourceFile].
				outStream nextChunkPut: ' '; cr]].
		moveSource ifTrue: [
			endPos _ outStream position.
			method checkOKToAdd: endPos - newPos at: newPos.
			method setSourcePosition: newPos inFile: fileIndex]].
	^ outStream