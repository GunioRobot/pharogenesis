mouseSelect: clickPoint 
	"Track text selection and answer with an Array of two CharacterBlocks."
	| startBlock |
	startBlock := self characterBlockAtPoint: clickPoint.
	self reverseFrom: startBlock to: startBlock.
	^ self mouseMovedFrom: startBlock 
		pivotBlock: startBlock
		showingCaret: true