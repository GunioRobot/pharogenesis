gridTrack: trackIndex toQuarter: quarterDelta at: indexInTrack

	| track selStartTime delta |
	track _ tracks at: trackIndex.
	selStartTime _ (track at: indexInTrack) time.
	delta _ (self gridToQuarterNote: selStartTime + (quarterDelta*ticksPerQuarterNote))
				- selStartTime.
	indexInTrack to: track size do:
		[:i | (track at: i) adjustTimeBy: delta].
