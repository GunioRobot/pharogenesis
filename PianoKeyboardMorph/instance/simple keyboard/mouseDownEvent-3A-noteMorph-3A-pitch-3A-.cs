mouseDownEvent: event noteMorph: noteMorph pitch: midiKey
	| pitch |
	event hand hasSubmorphs ifTrue: [^ self  "no response if drag something over me"].
	noteMorph color: playingKeyColor.
	pitch _ AbstractSound pitchForMIDIKey: midiKey + 23.
	soundPlaying ifNotNil: [soundPlaying stopGracefully].
	soundPlaying _ soundPrototype soundForPitch: pitch dur: 100.0 loudness: 0.3.
	SoundPlayer resumePlaying: soundPlaying quickStart: true.
