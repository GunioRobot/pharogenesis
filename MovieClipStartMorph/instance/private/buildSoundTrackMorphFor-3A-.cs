buildSoundTrackMorphFor: pianoRoll
	| stopTime soundTrackForm startTime samplesPerTick samplesPerMs |
	soundTrackTimeScale := pianoRoll timeScale.  "pixels per tick"
	samplesPerTick := moviePlayerMorph scorePlayer originalSamplingRate   "Samples per sec"
						* pianoRoll scorePlayer secsPerTick.  "secs per tick"
	samplesPerMs := moviePlayerMorph scorePlayer originalSamplingRate / 1000.0.
	startTime := frameNumber * moviePlayerMorph msPerFrame.  "ms"
	stopTime := endMorph frameNumber * moviePlayerMorph msPerFrame.
	soundTrackForm := moviePlayerMorph scorePlayer
		volumeForm: self soundTrackHeight
		from: (startTime * samplesPerMs) rounded
		to: (stopTime * samplesPerMs) rounded
		nSamplesPerPixel: samplesPerTick / soundTrackTimeScale.
	^ soundTrackMorph := ImageMorph new image: soundTrackForm