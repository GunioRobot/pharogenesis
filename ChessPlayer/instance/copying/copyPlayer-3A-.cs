copyPlayer: aPlayer
	"Copy all the volatile state from aPlayer"
	castlingRookSquare _ aPlayer castlingRookSquare.
	enpassantSquare _ aPlayer enpassantSquare.
	castlingStatus _ aPlayer castlingStatus.
	materialValue _ aPlayer materialValue.
	numPawns _ aPlayer numPawns.
	positionalValue _ aPlayer positionalValue.
	pieces replaceFrom: 1 to: pieces size with: aPlayer pieces startingAt: 1.