changeTargetColorTo: aColor

	self applyToWholeText ifTrue: [
		lastGlobalColor _ aColor
	].
	self changeSelectionAttributeTo: (TextColor color: aColor)