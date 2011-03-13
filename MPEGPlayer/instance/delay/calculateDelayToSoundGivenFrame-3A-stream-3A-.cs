calculateDelayToSoundGivenFrame: frame stream: aStream
	| current delta buffers estimatedAudio estimatedVideo |

	current :=  Time millisecondClockValue   - (self startTimeForStream: aStream) + (self clockBiasForStream: aStream).
	buffers := (self soundQueue sounds size - 1 ) max: 0.
	buffers = 0 ifTrue: [^self].
	estimatedAudio :=  ((self currentAudioSampleForStream: aStream) 
			- (buffers * self sampleRate // 10) 
			- self soundQueue currentSound samplesRemaining) * 1000 / self sampleRate.
	estimatedAudio := estimatedAudio - 0000.
	estimatedVideo := ((frame asFloat / self frameRate) * 1000) asInteger.
	delta := estimatedVideo - estimatedAudio.
	delta > 100  ifTrue: 
		[self lastDelay < delta ifTrue: [self lastDelay: self lastDelay + (((delta-self lastDelay)/10) max: 1)].
		(Delay forMilliseconds: self lastDelay) wait].
	delta < -100  ifTrue: 
		[self lastDelay: ((self lastDelay - 10) max: 1).
		 self decideToSkipAFrame: delta averageWait: current//frame stream: aStream].
