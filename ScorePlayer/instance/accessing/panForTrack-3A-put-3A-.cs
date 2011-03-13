panForTrack: trackIndex put: aNumber
	"Set the left-right pan for this track to a value in the range [0.0..1.0], where 0.0 means full-left."

	| fullVol pan left right |
	trackIndex > leftVols size ifTrue: [^ self].
	fullVol _ (leftVols at: trackIndex) max: (rightVols at: trackIndex).
	pan _ (aNumber asFloat min: 1.0) max: 0.0.
	pan <= 0.5
		ifTrue: [  "attenuate right channel"
			left _ fullVol.
			right _ 2.0 * pan * fullVol]
		ifFalse: [  "attenuate left channel"
			left _ 2.0 * (1.0 - pan) * fullVol.
			right _ fullVol].
	rightVols at: trackIndex put: right asInteger.
	leftVols at: trackIndex put: left asInteger.
