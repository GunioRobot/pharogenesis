resetForStereo
	"Reset my encoding and decoding state for stereo."

	"keep state as SoundBuffers to allow fast access from primitive"
	predicted _ SoundBuffer new: 2.
	index _ SoundBuffer new: 2.
