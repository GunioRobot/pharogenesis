volumeForTrack: i

	| total |
	total _ (leftVols at: i) + (rightVols at: i).
	^ (total asFloat / ScaleFactor) roundTo: 0.0001
