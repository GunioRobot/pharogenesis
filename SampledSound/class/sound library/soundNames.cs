soundNames
	"Return a list of sound names for the sounds stored in the sound library."
	"SampledSound soundNames do: [:n | SampledSound playSoundNamed: n]"

	^ SoundLibrary keys asArray
