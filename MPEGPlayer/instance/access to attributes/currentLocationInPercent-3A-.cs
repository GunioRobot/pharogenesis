currentLocationInPercent: aStream

	self hasVideo ifTrue: [^ ((self currentVideoFrameForStream: aStream)/(self videoFrames: aStream)) asFloat].
	self hasAudio ifTrue: [^ ((self currentAudioSampleForStream: aStream)/(self audioSamples: aStream)) asFloat].

