labels: aString lines: linesArray selections: selectionsArray
	"Answer an instance of me whose items are in aString, with lines drawn 
	after each item indexed by anArray. Record the given array of selections
	corresponding to the items in labelsArray."

	^ (self labels: aString lines: linesArray) selections: selectionsArray