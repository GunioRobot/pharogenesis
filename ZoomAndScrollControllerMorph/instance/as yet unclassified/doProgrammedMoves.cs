doProgrammedMoves

	| thisMove startPoint endPoint startZoom endZoom newScale newPoint fractionLeft |

	programmedMoves isEmptyOrNil ifTrue: [
		^programmedMoves _ nil
	].
	thisMove _ programmedMoves first.
	thisMove at: #pauseTime ifPresent: [ :ignore | ^self].

	fractionLeft _ self fractionLeftInMove: thisMove.
	fractionLeft ifNil: [^programmedMoves _ programmedMoves allButFirst].

	startPoint _ thisMove at: #startPoint ifAbsentPut: [self cameraPoint].
	endPoint _ thisMove at: #endPoint ifAbsentPut: [self cameraPoint].

	startZoom _ thisMove at: #startZoom ifAbsentPut: [self cameraScale].
	endZoom _ thisMove at: #endZoom ifAbsentPut: [self cameraScale].
	newScale _ endZoom - (endZoom - startZoom * fractionLeft).
	newPoint _ (endPoint - (endPoint - startPoint * fractionLeft)) "rounded".
	target changeScaleTo: newScale.
	target cameraPoint: newPoint.

	fractionLeft <= 0 ifTrue: [^programmedMoves _ programmedMoves allButFirst].

