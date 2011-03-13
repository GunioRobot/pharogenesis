playMouseLeaveSound
	"TrashCanMorph playMouseLeaveSound"

	| snd |
	Smalltalk at: #SampledSound ifPresent: [:sampledSound |
		snd _ sampledSound
			samples: self samplesForMouseLeave
				samplingRate: 22050.
		snd play].
