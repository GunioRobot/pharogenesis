applyDoublePushMove: move
	enpassantSquare _ (move sourceSquare + move destinationSquare) bitShift: -1.
	"Above means: the field between start and destination"
	^self movePiece: move movingPiece from: move sourceSquare to: move destinationSquare.