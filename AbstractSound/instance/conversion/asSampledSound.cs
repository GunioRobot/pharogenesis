asSampledSound
	^SampledSound samples: (self computeSamplesForSeconds: self 
duration) samplingRate: (self samplingRate)*2.
