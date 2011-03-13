setTOCEntry: newTOCentry 
	"Change the currently selected message. This is done by finding the  
	message ID corresponding to the selected table of contents entry."
	| i |
	newTOCentry isNil | currentTOC isNil
		ifTrue: [currentMsgID _ nil]
		ifFalse: [i _ (self tocLists at: 1)
						indexOf: newTOCentry
						ifAbsent: [].
			i isNil
				ifTrue: [currentMsgID _ nil]
				ifFalse: [currentMsgID _ currentMessages at: i]].
	self changed: #tocEntry.
	Cursor read
		showWhile: [self changed: #messageText]