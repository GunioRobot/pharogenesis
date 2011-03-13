boinkScale
	"Tests the sound output primitives by playing a scale."
	"SoundPlayer boinkScale"

	| sineTable pan |
	self shutDown.
	SamplingRate _ 11025.
	Stereo _ true.
	sineTable _ self sineTable: 1000.
	Buffer _ SoundBuffer sampleCount: 1000.
	BufferIndex _ 1.
	self primSoundStartBufferSize: Buffer sampleCount rate: SamplingRate stereo: Stereo.
	self primSoundPlaySilence.
	pan _ 0.
	#(261.626 293.665 329.628 349.229 391.996 440.001 493.884 523.252) do: [ :p |
		self boinkPitch: p dur: 0.3 loudness: 300 waveTable: sineTable pan: pan.
		pan _ pan + 125.
	].
	self boinkPitch: 261.626 dur: 1.0 loudness: 300 waveTable: sineTable pan: 500.
	self primSoundStop.
