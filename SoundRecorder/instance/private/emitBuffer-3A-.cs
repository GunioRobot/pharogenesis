emitBuffer: buffer

	| sound |
	sound _ SampledSound new setSamples: buffer samplingRate: samplingRate.
	recordedSound add:
		(codec == nil
			ifTrue: [sound]
			ifFalse: [codec compressSound: sound])