makeTile
	| tile |
	recorder pause.
	tile _ InterimSoundMorph new sound: 
		(SampledSound
			samples: recorder condensedSamples
			samplingRate: recorder samplingRate).

	self world hands first attachMorph: tile.
