ambientEventAfter: eventIndex ticks: scoreTicks
	| evt |
	(ambientTrack == nil or: [eventIndex > ambientTrack size]) ifTrue: [^ nil].
	evt _ ambientTrack at: eventIndex.
	evt time <= scoreTicks ifTrue: [^ evt].
	^ nil