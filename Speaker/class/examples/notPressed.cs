notPressed
	"
	Speaker notPressed say: 'This is a non pressed voice.'
	"

	^ self new
		pitch: 100.0;
		voice: (KlattVoice new ro: 0.9)