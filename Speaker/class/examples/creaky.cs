creaky
	"
	Speaker creaky say: 'This is my creaky voice with hight jitter and shimmer.'
	"

	^ self new
		pitch: 90.0;
		speed: 0.5;
		voice: (KlattVoice new jitter: 0.5; shimmer: 0.5)