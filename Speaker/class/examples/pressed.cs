pressed
	"
	Speaker pressed say: 'This is a pressed voice.'
	"

	^ self new
		pitch: 100.0;
		voice: (KlattVoice new ro: 0.1)