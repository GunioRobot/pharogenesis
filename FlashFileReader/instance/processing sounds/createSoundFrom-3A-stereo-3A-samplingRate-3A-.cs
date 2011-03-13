createSoundFrom: soundBuffers stereo: stereo samplingRate: samplingRate

	| snds |
	snds := soundBuffers collect: [:buf |
		(SampledSound samples: buf samplingRate: samplingRate) loudness: 1.0].
	stereo
		ifTrue:[
			^ MixedSound new
				add: (snds at: 1) pan: 0.0;
				add: (snds at: 2) pan: 1.0;
				yourself]
		ifFalse: [
			^ snds at: 1].