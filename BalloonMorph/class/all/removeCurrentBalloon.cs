removeCurrentBalloon
	"Make the current help balloon, if any, disappear."

	CurrentBalloon ifNotNil: [
		CurrentBalloon delete.
		CurrentBalloon _ nil].
