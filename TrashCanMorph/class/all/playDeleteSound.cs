playDeleteSound
	"TrashCanMorph playDeleteSound"

	| snd |
	Smalltalk at: #SampledSound ifPresent: [:sampledSound |
		snd _ sampledSound
			samples: self samplesForDelete
			samplingRate: 22050.
		snd play].
