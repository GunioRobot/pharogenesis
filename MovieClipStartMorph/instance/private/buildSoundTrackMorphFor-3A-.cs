buildSoundTrackMorphFor: pianoRoll
	| stopTime soundTrackForm startTime samplesPerTick samplesPerMs |
	soundTrackTimeScale _ pianoRoll timeScale.  "pixels per tick"
	samplesPerTick _ moviePlayerMorph scorePlayer originalSamplingRate   "Samples per sec"
						* pianoRoll scorePlayer secsPerTick.  "secs per tick"
	samplesPerMs _ moviePlayerMorph scorePlayer originalSamplingRate / 1000.0.
	startTime _ frameNumber * moviePlayerMorph msPerFrame.  "ms"
	stopTime _ endMorph frameNumber * moviePlayerMorph msPerFrame.
	soundTrackForm _ moviePlayerMorph scorePlayer
		volumeForm: self soundTrackHeight
		from: (startTime * samplesPerMs) rounded
		to: (stopTime * samplesPerMs) rounded
		nSamplesPerPixel: samplesPerTick / soundTrackTimeScale.
	^ soundTrackMorph _ ImageMorph new image: soundTrackForm