setLocation: aPercentage forStream: aStream
	self hasAudio ifTrue: [self currentAudioSampleForStream: aStream put: ((self audioSamples: aStream) * aPercentage) asInteger]. 
	self hasVideo ifTrue: [self currentVideoFrameForStream: aStream put: ((self videoFrames: aStream) * aPercentage) asInteger].