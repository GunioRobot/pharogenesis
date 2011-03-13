encounteredAtTime: ticks inScorePlayer: scorePlayer atIndex: index inEventTrack: track secsPerTick: secsPerTick

	"If being shown as a clip, then tell the clipPlayer to start showing this clip"
	movieClipPlayer setCueMorph: self.
	movieClipPlayer openFileNamed: movieClipFileName
			withScorePlayer: soundTrackPlayerReady copy
			andPlayFrom: frameNumber.
