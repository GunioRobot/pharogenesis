addViewingItemsTo: aMenu
	"Add viewing-related items to the given menu.  If any are added, this method is also responsible for adding a line after them"

	#(	(viewingByIconString 			viewByIcon)
		(viewingByNameString 			viewByName)
		"(viewingBySizeString 			viewBySize)"
		(viewingNonOverlappingString 	viewNonOverlapping)) do:
			[:pair |  aMenu addUpdating: pair first target:  self action: pair second].
	aMenu addLine
