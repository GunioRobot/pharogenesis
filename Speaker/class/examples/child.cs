child
	"
	Speaker child say: 'Hello. I am a child speaking.'
	"

	^ self new
		pitch: 320.0;
		voice: (KlattVoice new tract: 12)