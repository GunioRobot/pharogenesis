acceptDroppingMorph: aMorph event: anEvent
	| destSquare sourceSquare |
	sourceSquare _ aMorph valueOfProperty: #chessBoardSourceSquare.
	aMorph removeProperty: #chessBoardSourceSquare.
	destSquare _ self asSquare: aMorph center.
	"!!! ACTUAL MOVE HAPPENS INDIRECTLY !!!"
	(self atSquare: sourceSquare) addMorphCentered: aMorph.
	destSquare ifNil:[^self].
	self movePieceFrom: sourceSquare to: destSquare.
	self showMovesAt: destSquare.