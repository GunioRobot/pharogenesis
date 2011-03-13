encounteredAtTime: ticks inScorePlayer: scorePlayer atIndex: index inEventTrack: track secsPerTick: secsPerTick

	movieClipPlayer ifNotNil:
		["If being shown as a clip, then tell the clipPlayer to stop showing this clip"
		movieClipPlayer stopRunning]