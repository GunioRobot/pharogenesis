calculateDelayToSoundGivenFrame: frame stream: aStream
	| current delta buffers estimatedAudio estimatedVideo |

	current _  Time millisecondClockValue   - (self startTimeForStream: aStream) + (self clockBiasForStream: aStream).
	buffers _ (self soundQueue sounds size - 1 ) max: 0.
	buffers = 0 ifTrue: [^self].
	estimatedAudio _  ((self currentAudioSampleForStream: aStream) 
			- (buffers * self sampleRate // 10) 
			- self soundQueue currentSound samplesRemaining) * 1000 / self sampleRate.
	estimatedAudio _ estimatedAudio - 0000.
	estimatedVideo _ ((frame asFloat / self frameRate) * 1000) asInteger.
	delta _ estimatedVideo - estimatedAudio.
	delta > 100  ifTrue: 
		[self lastDelay < delta ifTrue: [self lastDelay: self lastDelay + (((delta-self lastDelay)/10) max: 1)].
		(Delay forMilliseconds: self lastDelay) wait].
	delta < -100  ifTrue: 
		[self lastDelay: ((self lastDelay - 10) max: 1).
		 self decideToSkipAFrame: delta averageWait: current//frame stream: aStream].
