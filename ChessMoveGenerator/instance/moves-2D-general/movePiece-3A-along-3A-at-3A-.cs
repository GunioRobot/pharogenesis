movePiece: piece along: rayList at: square
	| destSquare capture |
	1 to: rayList size do:[:i|
		destSquare _ rayList at: i.
		(myPieces at: destSquare) = 0 ifFalse:[^self].
		capture _ itsPieces at: destSquare.
		(forceCaptures and:[capture = 0]) ifFalse:[
			(moveList at: (lastMoveIndex _ lastMoveIndex + 1))
				move: piece from: square to: destSquare capture: capture.
			capture = King ifTrue:[kingAttack _ moveList at: lastMoveIndex].
		].
		capture = 0 ifFalse:[^self].
	].