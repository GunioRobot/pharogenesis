msgIDFromTOCEntry: newTOCentry 
	"Given an entry from the TOC pane, find the corresponding msgID"

	^currentMessages at: (Integer readFromString: (newTOCentry allButFirst: 3))
