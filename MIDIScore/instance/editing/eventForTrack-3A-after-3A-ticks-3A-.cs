eventForTrack: trackIndex after: eventIndex ticks: scoreTick

	| track evt |
	track _ tracks at: trackIndex.
	eventIndex > track size ifTrue: [^ nil].
	evt _ track at: eventIndex.
	evt time > scoreTick ifTrue: [^ nil].
	^ evt
