writeToFile

	state = #active ifFalse: [self error: 'wrong state'. ^ self].
	Cursor write showWhile: [
		segmentName ifNil: [
			segmentName _ (FileDirectory localNameFor: fileName) sansPeriodSuffix].
			"OK that still has number on end.  This is an unusual case"
		fileName _ self class uniqueFileNameFor: segmentName.	"local name"
		(self class segmentDirectory newFileNamed: fileName) nextPutAll: segment; close.
		segment _ nil.
		endMarker _ nil.
		state _ #onFile].