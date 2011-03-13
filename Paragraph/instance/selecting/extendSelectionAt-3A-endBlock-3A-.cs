extendSelectionAt: beginBlock endBlock: endBlock 
	"Answer with an Array of two CharacterBlocks that represent the text 
	selection that the user makes."
	
	(self characterBlockAtPoint: Sensor cursorPoint) <= beginBlock
		ifTrue: [^self mouseMovedFrom: beginBlock 
					pivotBlock: endBlock
					showingCaret: (beginBlock = endBlock)]
		ifFalse: [^self mouseMovedFrom: endBlock 
					pivotBlock: beginBlock
					showingCaret: (beginBlock = endBlock)]
