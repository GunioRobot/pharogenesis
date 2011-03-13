text: aString
	"Add onto the end of the file"

	| this aFile start end |
	this _ String streamContents: [:ss | 
		ss nextPutAll: self chunk1.
		aString storeOn: ss.
		ss nextPutAll: ' back: '].
	(aFile _ FileStream fileNamed: file) setToEnd.
	start _ aFile position.
	aFile nextChunkPut: this; skip: -1.	"undo the ! at end"
	end _ aFile position.
	aFile nextPutAll: (end - start) printString; nextPut: $!; cr; close.
