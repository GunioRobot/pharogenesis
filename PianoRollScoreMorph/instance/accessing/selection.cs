selection
	"Returns an array of 3 elements:
		trackIndex
		indexInTrack of first note
		indexInTrack of last note"

	| trackIndex track |
	selection ifNil:  "If no selection, return last event of 1st non-muted track (or nil)"
		[trackIndex _ (1 to: score tracks size)
			detect: [:i | (scorePlayer mutedForTrack: i) not] ifNone: [^ nil].
		track _ score tracks at: trackIndex.
		^ Array with: trackIndex with: track size with: track size].
	(scorePlayer mutedForTrack: selection first)
		ifTrue: [selection _ nil.  ^ self selection].
	^ selection