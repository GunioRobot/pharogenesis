movePieceFrom: sourceSquare to: destSquare
	board ifNil:[^self].
	board searchAgent isThinking ifTrue:[^self].
	board movePieceFrom: sourceSquare to: destSquare.
	board searchAgent startThinking.