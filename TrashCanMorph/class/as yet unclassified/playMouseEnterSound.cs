playMouseEnterSound
	"TrashCanMorph playMouseEnterSound"

	| snd |
	Smalltalk at: #SampledSound ifPresent: [:sampledSound |
		snd _ sampledSound
				samples: self samplesForMouseEnter
			samplingRate: 22050.
		snd play].
