checkUnprotectedAttack:squares fromPiece:piece
	"check to see if my opponent has a piece of type piece on any of squares.  In general, this
	is used because that piece could launch an attack on me from those squares".
	squares do:[:sqr|
		(itsPieces at:sqr) = piece ifTrue:[^true].
	].
	^false.
	
	
