seekVideoAudioBasedOnFrame: aFrame forStream: aStream
	self external hasVideo ifTrue: 
		[self currentVideoFrameForStream: aStream put:  aFrame].
	self recalculateNewSampleLocationForStream: aStream givenFrame: aFrame