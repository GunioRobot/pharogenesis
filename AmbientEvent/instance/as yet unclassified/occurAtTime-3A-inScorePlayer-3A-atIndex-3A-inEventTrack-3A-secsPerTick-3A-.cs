occurAtTime: ticks inScorePlayer: player atIndex: index inEventTrack: track secsPerTick: secsPerTick
	(target == nil or: [selector == nil]) ifTrue:
		[^ morph encounteredAtTime: ticks inScorePlayer: player atIndex: index inEventTrack: track secsPerTick: secsPerTick].
	target perform: selector withArguments: arguments