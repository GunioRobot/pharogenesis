processAmbientEventsAtTick: scoreTick
	"Process ambient events through the given tick."

	| i evt |
	i _ trackEventIndex at: trackEventIndex size.
	[evt _ score ambientEventAfter: i ticks: scoreTick.
	 evt ~~ nil] whileTrue: [
		i _ i + 1.
		evt occurAtTime: scoreTick inScorePlayer: self atIndex: i inEventTrack: score ambientTrack secsPerTick: secsPerTick].
	trackEventIndex at: trackEventIndex size put: i.
