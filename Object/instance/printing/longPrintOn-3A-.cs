longPrintOn: aStream 
	"Append to the argument, aStream, the names and values of all its instance variables."

	self class allInstVarNames
		doWithIndex: [:title :index |
			aStream nextPutAll: title; nextPut: $:; space; tab.
			(self instVarAt: index) printOn: aStream.
			aStream cr].