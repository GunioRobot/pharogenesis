beep

	Smalltalk at: #SampledSound ifPresent: [:sampledSound |
		(sampledSound new
			setSamples: sampledSound coffeeCupClink
			samplingRate: 12000) play.
		^ self].

	Smalltalk beep.
