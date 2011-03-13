setPitch: p dur: d loudness: l
	"This is just a WaveTableSound that decays by default."
	"(BoinkSound pitch: 880.0 dur: 2.0 loudness: 1000) play"

	super setPitch: p dur: d loudness: l.
	decayRate _ 0.92.
