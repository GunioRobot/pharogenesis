updateToc
	| s |
	currentTOC _ OrderedCollection new: currentMessages size.
	1 to: currentMessages size do: 
		[:i | 
		s _ WriteStream on: (String new: 100).
		s nextPutAll: i printString;
		 space.
		[s position < 4]
			whileTrue: [s space].
		s nextPutAll: (mailDB getTOCstring: (currentMessages at: i)).
		currentTOC add: s contents].
	currentTOC _ currentTOC asArray.
	(currentMessages includes: currentMsgID)
		ifFalse: [currentMsgID _ nil]