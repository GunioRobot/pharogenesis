videoLoop: aStream
	| location oneTime | 

	oneTime _ true.
	[self external videoReadFrameInto: self form stream: aStream.
	oneTime ifTrue: 
			[oneTime _ false.
			self noSound ifFalse: 
				[self playAudioStreamNoSeek: aStream.
				semaphoreForSound wait.
				(Delay forMilliseconds: errorForSoundStart) wait].
			self startTimeForStream: aStream put: (Time millisecondClockValue)].
	self morph ifNil: 
			[self form == Display
				ifTrue: [Display forceToScreen]
				ifFalse: [self form displayOn: Display]].
	self changed.
		location _ (self currentVideoFrameForStream: aStream)+1.
	true 
			ifTrue: [self calculateDelayGivenFrame: location stream: aStream]
			ifFalse: [self calculateDelayToSoundGivenFrame: location stream: aStream].
	(self endOfVideo: aStream)  ifTrue: [^self]] repeat.