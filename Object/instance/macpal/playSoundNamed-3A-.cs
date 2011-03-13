playSoundNamed: soundName
	"Play the sound with the given name. Do nothing if this image lacks sound playing facilities."

	Smalltalk at: #SampledSound ifPresent: [:sampledSound |
		sampledSound playSoundNamed: soundName asString].
