volumeForTrack: i put: aNumber

	| oldTotal newTotal left |
	oldTotal _ (leftVols at: i) + (rightVols at: i).
	newTotal _ (aNumber asFloat min: 1.0) * ScaleFactor.
	oldTotal = 0
		ifTrue: [left _ newTotal // 2]
		ifFalse: [left _ ((newTotal * (leftVols at: i)) / oldTotal) asInteger].
	leftVols at: i put: left.
	rightVols at: i put: (newTotal - left).
