setTOCEntry: newTOCentry
	"Change the currently selected message. This is done by finding the message ID corresponding to the selected table of contents entry."

	| i |
	(newTOCentry isNil | currentTOC isNil)
		ifTrue: [currentMsgID _ nil]
		ifFalse:
			[i _ currentTOC indexOf: newTOCentry ifAbsent: [nil].
			 (i isNil)
				ifTrue: [currentMsgID _ nil]
				ifFalse: [currentMsgID _ currentMessages at: i]].

	self changed: #tocEntry.
	self changed: #messageText.
