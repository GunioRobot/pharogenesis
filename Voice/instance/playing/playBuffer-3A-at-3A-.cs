playBuffer: buffer at: time
	| tail |
	tail _ SampledSound samples: buffer samplingRate: self samplingRate.
	sound isNil
		ifTrue: [sound _ QueueSound new startTime: time - SoundPlayer bufferMSecs.
				sound add: tail; play]
		ifFalse: [sound add: tail]