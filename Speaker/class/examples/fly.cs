fly
	"
	Speaker fly say: 'Haaaaaalp.'
	"

	^ self new
		pitch: 650.0;
		loudness: 0.5;
		speed: 0.8;
		voice: (KlattVoice new flutter: 1.0; tract: 1)