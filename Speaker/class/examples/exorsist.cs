exorsist
	"
	Speaker exorsist say: 'This is an scary voice. Boo.'
	"

	^ self new
		pitch: 40.0;
		speed: 0.5;
		voice: (KlattVoice new tract: 10; diplophonia: 0.4; jitter: 0.3; shimmer: 0.5; turbulence: 50)