movedPiece: piece from: sourceSquare to: destSquare
	| sourceMorph destMorph sourcePos destPos w startTime nowTime deltaTime |
	sourceMorph _ (self atSquare: sourceSquare) firstSubmorph.
	destMorph _ self atSquare: destSquare.
	animateMove ifTrue:[
		sourcePos _ sourceMorph boundsInWorld center.
		destPos _ destMorph boundsInWorld center.
		(w _ self world) ifNotNil:[
			w addMorphFront: sourceMorph.
			sourceMorph addDropShadow.
			sourceMorph shadowColor: (Color black alpha: 0.5).
			deltaTime _ (sourcePos dist: destPos) * 10 asInteger.
			startTime _ Time millisecondClockValue.
			[nowTime _ Time millisecondClockValue.
			nowTime - startTime < deltaTime] whileTrue:[
				sourceMorph center: sourcePos + (destPos - sourcePos * (nowTime - startTime) // deltaTime) asIntegerPoint.
				w displayWorldSafely].
			sourceMorph removeDropShadow.
		].
	].
	destMorph removeAllMorphs.
	destMorph addMorphCentered: sourceMorph.
	animateMove _ false.