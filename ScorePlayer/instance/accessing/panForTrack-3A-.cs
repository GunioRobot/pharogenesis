panForTrack: i

	^ ((leftVols at: i) asFloat / ((leftVols at: i) + (rightVols at: i))) roundTo: 0.001
