nextSyncEventAfter: index inTrack: track
	| evt |
	index to: track size do:
		[:i | evt _ track at: i.
		(evt morph isMemberOf: MovieFrameSyncMorph) ifTrue: [^ evt]].
	^ nil