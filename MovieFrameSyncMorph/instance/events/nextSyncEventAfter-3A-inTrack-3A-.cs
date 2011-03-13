nextSyncEventAfter: index inTrack: track
	| evt |
	index to: track size do:
		[:i | evt := track at: i.
		((evt morph isMemberOf: self class)
			and: [evt morph moviePlayerMorph == moviePlayerMorph])
			ifTrue: [^ evt]].
	^ nil