panForTrack: i put: aNumber
	"Set the left-right pan for this track to a value in the range [0.0..1.0], where 0.0 means full-left."

	| total left |
	total _ (leftVols at: i) + (rightVols at: i).
	left _ ((aNumber asFloat min: 1.0) * total) asInteger.
	leftVols at: i put: left.
	rightVols at: i put: (total - left).
