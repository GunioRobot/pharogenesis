extendSelectionMark: markBlock pointBlock: pointBlock 
	"Answer with an Array of two CharacterBlocks that represent the text 
	selection that the user makes."
	true 
		ifTrue:[^self mouseMovedFrom: pointBlock
					pivotBlock: markBlock
					showingCaret:(pointBlock = markBlock)]
		ifFalse:
		[	| beginBlock endBlock |
			beginBlock _ markBlock min: pointBlock.
			endBlock _ markBlock max: endBlock.
	
			(self characterBlockAtPoint: Sensor cursorPoint) <= beginBlock
				ifTrue: [^self mouseMovedFrom: beginBlock 
							pivotBlock: endBlock
							showingCaret: (beginBlock = endBlock)]
				ifFalse: [^self mouseMovedFrom: endBlock 
							pivotBlock: beginBlock
							showingCaret: (beginBlock = endBlock)]
		]
