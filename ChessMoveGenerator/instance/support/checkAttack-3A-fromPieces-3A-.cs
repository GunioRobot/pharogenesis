checkAttack:squares fromPieces:pieces
	"check for an unprotected attack along squares by one of pieces.  Squares is a list of 
	squares such that any piece in pieces can attack unless blocked by another piece.
	E.g., a Bishop of Queen on the file  B7 C6 D5 E4 F3 G2 H1 can attack A8 unless blocked by
	another piece.  To find out if A8 is under attack along B7 C6 D5 E4 F3 G2 H1, use
	checkAttack:{B7. C6.D5. E4. F3. G2. H1} fromPieces:BishopMovers.  Note the order is important;
	squares must be listed in increasing distance from the square of interest"

	squares do:[:sqr|
		"invariant: no piece has been seen on this file at all"
		"one of my pieces blocks any attack"
		(myPieces at:sqr) = 0 ifFalse:[^false].
		"One of its pieces blocks an attack unless it is the kind of piece that can move along this
		file: a Bishop or Queen for a diagonal and a Rook or Queen for a Horizontal or
		Verrtical File"
		(itsPieces at:sqr) = 0 ifFalse:[
			^pieces includes:(itsPieces at:sqr).
		].
		
	].
	"no pieces along file, no attack"
	^false.
	
	
