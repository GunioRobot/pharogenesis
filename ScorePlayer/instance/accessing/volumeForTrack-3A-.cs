volumeForTrack: i

	| vol |
	vol _ (leftVols at: i) max: (rightVols at: i).
	^ (vol asFloat / ScaleFactor) roundTo: 0.0001
