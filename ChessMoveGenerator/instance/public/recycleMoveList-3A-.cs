recycleMoveList: aChessMoveList
	(streamList at: streamListIndex) == aChessMoveList ifFalse:[^self error:'I am confused'].
	streamListIndex _ streamListIndex - 1.
	firstMoveIndex _ lastMoveIndex _ aChessMoveList startIndex - 1.
