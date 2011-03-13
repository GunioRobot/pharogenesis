endClipHere
	"Change set the termination time for this clip via the endMorph"

	cueMorph ifNil: [^ self].
	cueMorph setEndFrameNumber: frameNumber
