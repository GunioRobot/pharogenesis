readSoundChannel: aChannel stream: aStream
	| buffer result samples |

	samples _ (self sampleRate // 10)  min: 
		((self audioSamples: aStream) - (self currentAudioSampleForStream: aStream)).
	(samples == 0) ifTrue: [self error: 'Mpeg at end of stream, toss error, catch up high']. 
	buffer _ SoundBuffer newMonoSampleCount: samples.
	aChannel = 0 
		ifTrue: [result _ self external audioReadBuffer: buffer stream: 
					aStream channel: aChannel]
		ifFalse: [result _ self external audioReReadBuffer: buffer stream: 
					aStream channel: aChannel].
	^SampledSound samples: buffer samplingRate: self sampleRate.
