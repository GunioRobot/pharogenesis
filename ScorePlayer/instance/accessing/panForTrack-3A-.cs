panForTrack: i

	| left right fullVol pan |
	left _ leftVols at: i.
	right _ rightVols at: i.
	left = right ifTrue: [^ 0.5].  "centered"
	fullVol _ left max: right.
	left < fullVol
		ifTrue: [pan _ left asFloat / (2.0 * fullVol)]
		ifFalse: [pan _ 1.0 - (right asFloat / (2.0 * fullVol))].
	^ pan roundTo: 0.001

