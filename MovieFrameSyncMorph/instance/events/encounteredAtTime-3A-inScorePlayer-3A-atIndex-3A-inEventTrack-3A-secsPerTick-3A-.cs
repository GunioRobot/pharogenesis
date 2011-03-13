encounteredAtTime: ticks inScorePlayer: scorePlayer atIndex: index inEventTrack: track secsPerTick: secsPerTick
	| next |
	"Set frame number and milliseconds since start in case of drift"
	moviePlayerMorph frameNumber: frameNumber
		msSinceStart: scorePlayer millisecondsSinceStart.

	"If there is a later sync point, set the appropriate frame rate until then."
	(next _ self nextSyncEventAfter: index inTrack: track) == nil ifFalse:
		[moviePlayerMorph msPerFrame: (next time - ticks) * secsPerTick * 1000.0
						/ (next morph frameNumber - self frameNumber)].
