labels: labels lines: linesArray selections: selectionsArray
	"Answer an instance of me whose items are in labels, with lines drawn  
	after each item indexed by linesArray. Labels can be either a string  
	with embedded CRs, or a collection of strings. Record the given array of 
	selections corresponding to the items in labels."

	^ (self labels: labels lines: linesArray) selections: selectionsArray