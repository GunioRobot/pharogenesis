breathy
	"
	Speaker breathy say: 'This is my breathy voice.'
	"

	^ self new
		pitch: 100.0;
		voice: (KlattVoice new ro: 0.6; turbulence: 70)