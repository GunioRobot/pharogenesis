step
	| move |
	board searchAgent isThinking ifTrue:[
		move _ board searchAgent thinkStep.
		move ifNotNil:[
			animateMove _ true.
			board movePieceFrom: move sourceSquare 
					to: move destinationSquare].
	] ifFalse:[
		autoPlay ifTrue:[board searchAgent startThinking].
	].