on: aScorePlayer

	scorePlayer _ aScorePlayer.
	score _ aScorePlayer score.
	colorForTrack _ Color wheel: score tracks size.
	leftEdgeTime _ 0.
	timeScale _ 0.1.
	indexInTrack _ Array new: score tracks size withAll: 1.
	lastUpdateTick _ -1.

	self updateLowestNote
